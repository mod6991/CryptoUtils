using System;
using System.Collections.Generic;
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
        }

        private void EncDecFilesPage_Unloaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            InputFilesListBox.DragOver -= InputFilesListBox_DragOver;
            InputFilesListBox.Drop -= InputFilesListBox_Drop;
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
                        if (item.IsOfType(StorageItemTypes.File))
                        {
                            if (!ViewModel.InputFiles.Contains(item.Path))
                                ViewModel.InputFiles.Add(item.Path);
                        }
                    }
                }
            }
        }
    }
}
