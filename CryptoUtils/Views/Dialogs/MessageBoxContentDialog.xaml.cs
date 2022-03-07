﻿using Microsoft.UI.Xaml.Controls;

namespace CryptoUtils.Views.Dialogs
{
    public enum MessageType
    {
        Success,
        Warning,
        Error
    }

    public sealed partial class MessageBoxContentDialog : ContentDialog
    {
        public MessageBoxContentDialog(MessageType messageType, string message)
        {
            InitializeComponent();
            
            MessageType = messageType;
            Message = message;
        }

        public string Message { get; set; }
        public MessageType MessageType { get; set; }
    }
}
