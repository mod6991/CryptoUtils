using System;

namespace CryptoUtils.Models
{
    public enum EncryptionKeySource
    {
        RSA,
        Password
    }

    public class EncryptionKeySourceItem
    {
        public EncryptionKeySource KeySource { get; set; }
        public string DisplayName
        {
            get
            {
                switch (KeySource)
                {
                    case EncryptionKeySource.RSA: return "with RSA key";
                    case EncryptionKeySource.Password: return "with password";
                    default: throw new InvalidOperationException("Unknown EncryptionKeySource");
                }
            }
        }
    }
}
