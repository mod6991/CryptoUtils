using System;

namespace CryptoUtils.Models
{
    public enum EncryptionType
    {
        AES,
        ChaChaAES
    }

    public class EncryptionTypeItem
    {
        public EncryptionType Type { get; set; }
        public string DisplayName
        {
            get
            {
                switch (Type)
                {
                    case EncryptionType.AES: return "AES";
                    case EncryptionType.ChaChaAES: return "ChaCha20 and AES";
                    default: throw new InvalidOperationException("Unknown type");
                }
            }
        }
    }
}
