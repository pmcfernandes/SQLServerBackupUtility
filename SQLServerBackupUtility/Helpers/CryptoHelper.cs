using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SQLServerBackupUtility.Helpers
{
    internal static class CryptoHelper
    {
        private const string Header = "ENCRYPTEDv1\n";
        private static readonly byte[] HeaderBytes = Encoding.UTF8.GetBytes(Header);
        // entropy to bind protected data to this application; keep constant but not secret
        private static readonly byte[] Entropy = Encoding.UTF8.GetBytes("SQLServerBackupUtility_Protected_Entropy_v1");

        public static void WritePossiblyEncrypted(string path, string json)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));
            var plain = Encoding.UTF8.GetBytes(json ?? string.Empty);
            // Protect with DPAPI, user scope
            var encrypted = ProtectedData.Protect(plain, Entropy, DataProtectionScope.CurrentUser);
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                fs.Write(HeaderBytes, 0, HeaderBytes.Length);
                fs.Write(encrypted, 0, encrypted.Length);
            }
        }

        public static string ReadPossiblyEncrypted(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));
            var all = File.ReadAllBytes(path);
            if (all.Length >= HeaderBytes.Length)
            {
                bool hasHeader = true;
                for (int i = 0; i < HeaderBytes.Length; i++)
                {
                    if (all[i] != HeaderBytes[i])
                    {
                        hasHeader = false;
                        break;
                    }
                }
                if (hasHeader)
                {
                    var encrypted = new byte[all.Length - HeaderBytes.Length];
                    Array.Copy(all, HeaderBytes.Length, encrypted, 0, encrypted.Length);
                    var decrypted = ProtectedData.Unprotect(encrypted, Entropy, DataProtectionScope.CurrentUser);
                    return Encoding.UTF8.GetString(decrypted);
                }
            }
            // not encrypted - assume plain text JSON
            return File.ReadAllText(path);
        }
    }
}