using System;
using System.Collections.Generic;
using System.Linq;
using CryptoUtils.ViewModels;
using Microsoft.UI.Xaml.Controls;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;

namespace CryptoUtils.Views
{
    public sealed partial class EncDecFilesPage : Page
    {
        public EncDecFilesViewModel ViewModel { get; set; }

        public EncDecFilesPage()
        {
            InitializeComponent();

            Loaded += EncDecFilesPage_Loaded;
            Unloaded += EncDecFilesPage_Unloaded;

            ViewModel = new EncDecFilesViewModel();
        }

        private void EncDecFilesPage_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.XamlRoot = XamlRoot;

            InputFilesListBox.DragOver += InputFilesListBox_DragOver;
            InputFilesListBox.Drop += InputFilesListBox_Drop;
            OutputTextBox.DragOver += OutputTextBox_DragOver;
            OutputTextBox.Drop += OutputTextBox_Drop;
            KeyTextBox.DragOver += KeyTextBox_DragOver;
            KeyTextBox.Drop += KeyTextBox_Drop;
        }

        private void EncDecFilesPage_Unloaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            InputFilesListBox.DragOver -= InputFilesListBox_DragOver;
            InputFilesListBox.Drop -= InputFilesListBox_Drop;
            OutputTextBox.DragOver -= OutputTextBox_DragOver;
            OutputTextBox.Drop -= OutputTextBox_Drop;
            KeyTextBox.DragOver -= KeyTextBox_DragOver;
            KeyTextBox.Drop -= KeyTextBox_Drop;
        }

        private void InputFilesListBox_DragOver(object sender, Microsoft.UI.Xaml.DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
        }

        private async void InputFilesListBox_Drop(object sender, Microsoft.UI.Xaml.DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                IReadOnlyList<IStorageItem> items = await e.DataView.GetStorageItemsAsync();
                if (items.Count > 0)
                {
                    foreach (IStorageItem item in items)
                    {
                        if (item.IsOfType(StorageItemTypes.File) && !ViewModel.InputFiles.Contains(item.Path))
                            ViewModel.InputFiles.Add(item.Path);
                    }
                }
            }
        }

        private void OutputTextBox_DragOver(object sender, Microsoft.UI.Xaml.DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
        }

        private async void OutputTextBox_Drop(object sender, Microsoft.UI.Xaml.DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                IReadOnlyList<IStorageItem> items = await e.DataView.GetStorageItemsAsync();

                if (items.Count == 1)
                    ViewModel.Output = items.ElementAt(0).Path;
            }
        }

        private void KeyTextBox_DragOver(object sender, Microsoft.UI.Xaml.DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
        }

        private async void KeyTextBox_Drop(object sender, Microsoft.UI.Xaml.DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                IReadOnlyList<IStorageItem> items = await e.DataView.GetStorageItemsAsync();

                if (items.Count == 1)
                    ViewModel.KeyPath = items.ElementAt(0).Path;
            }
        }
    }
}
