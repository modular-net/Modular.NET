using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using Modular.NET.Core.Security;

namespace Modular.NET.Core.Managers
{
    public static class EncryptionManager
    {
        #region Static Methods

        private static void ValidateParameters(ref byte[] publicKey,
            ref byte[] privateKey)
        {
            if (publicKey == null)
            {
                if (Engine.Current?.EncryptionKeyPair?.PublicKey != null)
                {
                    publicKey = Engine.Current?.EncryptionKeyPair?.PublicKey;
                }
                else
                {
                    throw new ArgumentNullException(nameof(publicKey));
                }
            }

            if (privateKey == null)
            {
                if (Engine.Current?.EncryptionKeyPair?.PrivateKey != null)
                {
                    privateKey = Engine.Current?.EncryptionKeyPair?.PrivateKey;
                }
                else
                {
                    throw new ArgumentNullException(nameof(privateKey));
                }
            }
        }

        private static void ValidateParameters(string input,
            ref byte[] publicKey,
            ref byte[] privateKey)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            ValidateParameters(ref publicKey, ref privateKey);
        }

        private static void ValidateParameters(byte[] input,
            ref byte[] publicKey,
            ref byte[] privateKey)
        {
            if (input == null || input.Length == 0)
            {
                throw new ArgumentNullException(nameof(input));
            }

            ValidateParameters(ref publicKey, ref privateKey);
        }

        #endregion

        #region Nested

        public static class Aes
        {
            #region Static Methods

            /// <summary>
            ///     Generate Aes encryption key.
            /// </summary>
            /// <returns></returns>
            public static EncryptionKeyPair GenerateKeyPair()
            {
                var ret = new EncryptionKeyPair();
                using var aes = System.Security.Cryptography.Aes.Create();
                aes.GenerateKey();
                ret.PublicKey = aes.Key;

                aes.GenerateIV();
                ret.PrivateKey = aes.IV;

                return ret;
            }

            /// <summary>
            ///     Using AES algorithm to encrypt input text.
            /// </summary>
            /// <param name="clearText"></param>
            /// <param name="publicKey"></param>
            /// <param name="privateKey"></param>
            /// <returns></returns>
            private static byte[] SelfEncrypt(string clearText,
                byte[] publicKey,
                byte[] privateKey)
            {
                ValidateParameters(clearText, ref publicKey, ref privateKey);

                byte[] ret;
                using var aes = System.Security.Cryptography.Aes.Create();
                aes.Key = publicKey;
                aes.IV = privateKey;

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using var msEncrypt = new MemoryStream();
                using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (var swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(clearText);
                }

                ret = msEncrypt.ToArray();

                return ret;
            }

            /// <summary>
            ///     Using AES algorithm to encrypt input text.
            /// </summary>
            /// <param name="clearText"></param>
            /// <param name="publicKey"></param>
            /// <param name="privateKey"></param>
            /// <returns></returns>
            public static string Encrypt(string clearText,
                byte[] publicKey = null,
                byte[] privateKey = null)
            {
                return Convert.ToBase64String(SelfEncrypt(clearText, publicKey, privateKey));
            }

            /// <summary>
            ///     Using AES algorithm to encrypt input text.
            /// </summary>
            /// <param name="clearText"></param>
            /// <param name="keyPair"></param>
            /// <returns></returns>
            public static string Encrypt(string clearText,
                EncryptionKeyPair keyPair)
            {
                return Encrypt(clearText, keyPair.PublicKey, keyPair.PrivateKey);
            }

            /// <summary>
            ///     Using AES algorithm to encrypt input text with output URL friendly encrypted text.
            /// </summary>
            /// <param name="clearText"></param>
            /// <param name="publicKey"></param>
            /// <param name="privateKey"></param>
            /// <returns></returns>
            public static string UrlEncrypt(string clearText,
                byte[] publicKey = null,
                byte[] privateKey = null)
            {
                return WebUtility.UrlEncode(Convert.ToBase64String(SelfEncrypt(clearText, publicKey, privateKey)));
            }

            /// <summary>
            ///     Using AES algorithm to encrypt input text with output URL friendly encrypted text.
            /// </summary>
            /// <param name="clearText"></param>
            /// <param name="keyPair"></param>
            /// <returns></returns>
            public static string UrlEncrypt(string clearText,
                EncryptionKeyPair keyPair)
            {
                return UrlEncrypt(clearText, keyPair.PublicKey, keyPair.PrivateKey);
            }

            /// <summary>
            ///     Using AES algorithm to decrypt input text.
            /// </summary>
            /// <param name="cipherBytes"></param>
            /// <param name="publicKey"></param>
            /// <param name="privateKey"></param>
            /// <returns></returns>
            public static string SelfDecrypt(byte[] cipherBytes,
                byte[] publicKey,
                byte[] privateKey)
            {
                ValidateParameters(cipherBytes, ref publicKey, ref privateKey);

                string ret;
                using var aes = System.Security.Cryptography.Aes.Create();
                aes.Key = publicKey;
                aes.IV = privateKey;

                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using var msDecrypt = new MemoryStream(cipherBytes);
                using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using var srDecrypt = new StreamReader(csDecrypt);
                ret = srDecrypt.ReadToEnd();

                return ret;
            }

            /// <summary>
            ///     Using AES algorithm to decrypt input text.
            /// </summary>
            /// <param name="cipherText"></param>
            /// <param name="publicKey"></param>
            /// <param name="privateKey"></param>
            /// <returns></returns>
            public static string Decrypt(string cipherText,
                byte[] publicKey = null,
                byte[] privateKey = null)
            {
                var byteArr = Convert.FromBase64String(cipherText);
                return SelfDecrypt(byteArr, publicKey, privateKey);
            }

            /// <summary>
            ///     Using AES algorithm to decrypt input text.
            /// </summary>
            /// <param name="cipherText"></param>
            /// <param name="keyPair"></param>
            /// <returns></returns>
            public static string Decrypt(string cipherText,
                EncryptionKeyPair keyPair)
            {
                return Decrypt(cipherText, keyPair.PublicKey, keyPair.PrivateKey);
            }

            /// <summary>
            ///     Using AES algorithm to decrypt input text with casting output type.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="cipherText"></param>
            /// <param name="publicKey"></param>
            /// <param name="privateKey"></param>
            /// <returns></returns>
            public static T Decrypt<T>(string cipherText,
                byte[] publicKey = null,
                byte[] privateKey = null)
            {
                try
                {
                    return (T) TypeDescriptor.GetConverter(typeof(T))
                        .ConvertFrom(Decrypt(cipherText, publicKey, privateKey));
                }
                catch (Exception)
                {
                    return default;
                }
            }

            /// <summary>
            ///     Using AES algorithm to decrypt input text with casting output type.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="cipherText"></param>
            /// <param name="keyPair"></param>
            /// <returns></returns>
            public static T Decrypt<T>(string cipherText,
                EncryptionKeyPair keyPair)
            {
                return Decrypt<T>(cipherText, keyPair.PublicKey, keyPair.PrivateKey);
            }

            /// <summary>
            ///     Using AES algorithm to decrypt URL friendly input text.
            /// </summary>
            /// <param name="cipherText"></param>
            /// <param name="publicKey"></param>
            /// <param name="privateKey"></param>
            /// <returns></returns>
            public static string UrlDecrypt(string cipherText,
                byte[] publicKey = null,
                byte[] privateKey = null)
            {
                var byteArr = Convert.FromBase64String(WebUtility.UrlDecode(cipherText));
                return SelfDecrypt(byteArr, publicKey, privateKey);
            }

            /// <summary>
            ///     Using AES algorithm to decrypt URL friendly input text.
            /// </summary>
            /// <param name="cipherText"></param>
            /// <param name="keyPair"></param>
            /// <returns></returns>
            public static string UrlDecrypt(string cipherText,
                EncryptionKeyPair keyPair)
            {
                return UrlDecrypt(cipherText, keyPair.PublicKey, keyPair.PrivateKey);
            }

            /// <summary>
            ///     Using AES algorithm to decrypt URL friendly input text with casting output type.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="cipherText"></param>
            /// <param name="publicKey"></param>
            /// <param name="privateKey"></param>
            /// <returns></returns>
            public static T UrlDecrypt<T>(string cipherText,
                byte[] publicKey = null,
                byte[] privateKey = null)
            {
                try
                {
                    return (T) TypeDescriptor.GetConverter(typeof(T))
                        .ConvertFrom(UrlDecrypt(cipherText, publicKey, privateKey));
                }
                catch (Exception)
                {
                    return default;
                }
            }

            /// <summary>
            ///     Using AES algorithm to decrypt URL friendly input text with casting output type.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="cipherText"></param>
            /// <param name="keyPair"></param>
            /// <returns></returns>
            public static T UrlDecrypt<T>(string cipherText,
                EncryptionKeyPair keyPair)
            {
                return UrlDecrypt<T>(cipherText, keyPair.PublicKey, keyPair.PrivateKey);
            }

            #endregion
        }

        #endregion
    }
}
