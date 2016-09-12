using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace GAP.Utility
{
    public class Seguridad
    {
        public static string Encrypt(string text)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(Constantes.initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(Constantes.saltValue);

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(text);

            PasswordDeriveBytes password = new PasswordDeriveBytes
            (
                Constantes.passPhrase,
                saltValueBytes,
                Constantes.hashAlgorithm,
                Constantes.passwordIterations
            );

            byte[] keyBytes = password.GetBytes(Constantes.keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;

            ICryptoTransform encryptor = symmetricKey.CreateEncryptor
            (
                keyBytes,
                initVectorBytes
            );

            MemoryStream memoryStream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream
            (
                memoryStream,
                encryptor,
                CryptoStreamMode.Write
            );

            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            cryptoStream.FlushFinalBlock();

            byte[] cipherTextBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            string cipherText = Convert.ToBase64String(cipherTextBytes);

            return cipherText;
        }

        public static string Decrypt(string textoCifrado)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(Constantes.initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(Constantes.saltValue);
            byte[] cipherTextBytes = Convert.FromBase64String(textoCifrado);

            PasswordDeriveBytes password = new PasswordDeriveBytes
            (
                Constantes.passPhrase,
                saltValueBytes,
                Constantes.hashAlgorithm,
                Constantes.passwordIterations
            );
            byte[] keyBytes = password.GetBytes(Constantes.keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor
            (
                keyBytes,
                initVectorBytes
            );
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream
            (
                memoryStream,
                decryptor,
                CryptoStreamMode.Read
            );
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read
            (
                plainTextBytes,
                0,
                plainTextBytes.Length
            );

            memoryStream.Close();
            cryptoStream.Close();
            string plainText = Encoding.UTF8.GetString
            (
                plainTextBytes,
                0,
                decryptedByteCount
            );

            return plainText;
        }
    }
}