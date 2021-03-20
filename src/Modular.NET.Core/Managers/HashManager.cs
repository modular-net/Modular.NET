using System;
using System.Security.Cryptography;
using System.Text;

namespace Modular.NET.Core.Managers
{
    public static class HashManager
    {
        #region Static Methods

        /// <summary>
        ///     Common hash algorithm for hash input text.
        /// </summary>
        /// <param name="crypto"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private static string CommonHash(HashAlgorithm crypto,
            string text)
        {
            var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(text));
            return BitConverter.ToString(hashed)
                .Replace("-", string.Empty);
        }

        /// <summary>
        ///     Common HMAC for hash input text.
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="key"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private static string CommonHmacHash(string algorithm,
            ref byte[] key,
            string text)
        {
            key ??= GenerateHashedKey();

            using var crypto = HMAC.Create(algorithm);
            crypto.Key = key;
            var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(text));
            return BitConverter.ToString(hashed)
                .Replace("-", string.Empty);
        }

        /// <summary>
        ///     Generate random salt key.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string CreateSaltKey(int size)
        {
            return Convert.ToBase64String(GenerateHashedKey(size));
        }

        /// <summary>
        ///     Generate random hashed key.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static byte[] GenerateHashedKey(int size = 16)
        {
            var rng = RandomNumberGenerator.Create();
            var buff = new byte[size];
            rng.GetBytes(buff);

            return buff;
        }

        #endregion

        #region Nested

        // ReSharper disable once InconsistentNaming
        public static class MD5
        {
            #region Static Methods

            /// <summary>
            ///     Using MD5 algorithm to hash input text.
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public static string Hash(string text)
            {
                var crypto = System.Security.Cryptography.MD5.Create();
                return CommonHash(crypto, text);
            }

            /// <summary>
            ///     Using MD5 algorithm to hash input text with provided salt key or auto generate salt key. Default salt key size was
            ///     5.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="salt"></param>
            /// <param name="saltSize"></param>
            /// <returns></returns>
            public static string Hash(string text,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                return Hash($"{text}{salt}");
            }

            #endregion
        }

        public static class Sha1
        {
            #region Static Methods

            /// <summary>
            ///     Using SHA1 algorithm to hash input text.
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public static string Hash(string text)
            {
                var crypto = SHA1.Create();
                return CommonHash(crypto, text);
            }

            /// <summary>
            ///     Using SHA1 algorithm to hash input text with provided salt key or auto generate salt key. Default salt key size was
            ///     5.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="salt"></param>
            /// <param name="saltSize"></param>
            /// <returns></returns>
            public static string Hash(string text,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                return Hash($"{text}{salt}");
            }

            #endregion
        }

        public static class Sha256
        {
            #region Static Methods

            /// <summary>
            ///     Using SHA256 algorithm to hash input text.
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public static string Hash(string text)
            {
                var crypto = SHA256.Create();
                return CommonHash(crypto, text);
            }

            /// <summary>
            ///     Using SHA256 algorithm to hash input text with provided salt key or auto generate salt key. Default salt key size
            ///     was 5.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="salt"></param>
            /// <param name="saltSize"></param>
            /// <returns></returns>
            public static string Hash(string text,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                return Hash($"{text}{salt}");
            }

            #endregion
        }

        public static class Sha384
        {
            #region Static Methods

            /// <summary>
            ///     Using SHA384 algorithm to hash input text.
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public static string Hash(string text)
            {
                var crypto = SHA384.Create();
                return CommonHash(crypto, text);
            }

            /// <summary>
            ///     Using SHA384 algorithm to hash input text with provided salt key or auto generate salt key. Default salt key size
            ///     was 5.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="salt"></param>
            /// <param name="saltSize"></param>
            /// <returns></returns>
            public static string Hash(string text,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                return Hash($"{text}{salt}");
            }

            #endregion
        }

        public static class Sha512
        {
            #region Static Methods

            /// <summary>
            ///     Using SHA512 algorithm to hash input text.
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public static string Hash(string text)
            {
                var crypto = SHA512.Create();
                return CommonHash(crypto, text);
            }

            /// <summary>
            ///     Using SHA512 algorithm to hash input text with provided salt key or auto generate salt key. Default salt key size
            ///     was 5.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="salt"></param>
            /// <param name="saltSize"></param>
            /// <returns></returns>
            public static string Hash(string text,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                return Hash($"{text}{salt}");
            }

            #endregion
        }

        public static class Sha1Managed
        {
            #region Static Methods

            /// <summary>
            ///     Using SHA1 algorithm to hash input text.
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public static string Hash(string text)
            {
                var crypto = SHA1.Create();
                return CommonHash(crypto, text);
            }

            /// <summary>
            ///     Using SHA1 algorithm to hash input text with provided salt key or auto generate salt key. Default salt key size was
            ///     5.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="salt"></param>
            /// <param name="saltSize"></param>
            /// <returns></returns>
            public static string Hash(string text,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                return Hash($"{text}{salt}");
            }

            #endregion
        }

        public static class Sha256Managed
        {
            #region Static Methods

            /// <summary>
            ///     Using SHA256 algorithm to hash input text.
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public static string Hash(string text)
            {
                var crypto = SHA256.Create();
                return CommonHash(crypto, text);
            }

            /// <summary>
            ///     Using SHA256 algorithm to hash input text with provided salt key or auto generate salt key. Default salt key size
            ///     was 5.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="salt"></param>
            /// <param name="saltSize"></param>
            /// <returns></returns>
            public static string Hash(string text,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                return Hash($"{text}{salt}");
            }

            #endregion
        }

        public static class Sha384Managed
        {
            #region Static Methods

            /// <summary>
            ///     Using SHA384 algorithm to hash input text.
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public static string Hash(string text)
            {
                var crypto = SHA384.Create();
                return CommonHash(crypto, text);
            }

            /// <summary>
            ///     Using SHA384 algorithm to hash input text with provided salt key or auto generate salt key. Default salt key size
            ///     was 5.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="salt"></param>
            /// <param name="saltSize"></param>
            /// <returns></returns>
            public static string Hash(string text,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                return Hash($"{text}{salt}");
            }

            #endregion
        }

        public static class Sha512Managed
        {
            #region Static Methods

            /// <summary>
            ///     Using SHA512 algorithm to hash input text.
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public static string Hash(string text)
            {
                var crypto = SHA512.Create();
                return CommonHash(crypto, text);
            }

            /// <summary>
            ///     Using SHA512 algorithm to hash input text with provided salt key or auto generate salt key. Default salt key size
            ///     was 5.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="salt"></param>
            /// <param name="saltSize"></param>
            /// <returns></returns>
            public static string Hash(string text,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                return Hash($"{text}{salt}");
            }

            #endregion
        }

        // ReSharper disable once InconsistentNaming
        public static class HmacMD5
        {
            #region Static Methods

            /// <summary>
            ///     Using HMAC MD5 algorithm to hash input text.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="key"></param>
            /// <returns></returns>
            public static string Hash(string text,
                ref byte[] key)
            {
                return CommonHmacHash("HMACMD5", ref key, text);
            }

            /// <summary>
            ///     Using HMAC MD5 algorithm to hash input text with provided salt key or auto generate salt key. Default salt key size
            ///     was 5.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="key"></param>
            /// <param name="salt"></param>
            /// <param name="saltSize"></param>
            /// <returns></returns>
            public static string Hash(string text,
                ref byte[] key,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                return Hash($"{text}{salt}", ref key);
            }

            #endregion
        }

        public static class HmacSha1
        {
            #region Static Methods

            /// <summary>
            ///     Using HMAC SHA1 algorithm to hash input text.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="key"></param>
            /// <returns></returns>
            public static string Hash(string text,
                ref byte[] key)
            {
                return CommonHmacHash("HMACSHA1", ref key, text);
            }

            /// <summary>
            ///     Using HMAC SHA1 algorithm to hash input text with provided salt key or auto generate salt key. Default salt key
            ///     size was 6.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="key"></param>
            /// <param name="salt"></param>
            /// <param name="saltSize"></param>
            /// <returns></returns>
            public static string Hash(string text,
                ref byte[] key,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                return Hash($"{text}{salt}", ref key);
            }

            #endregion
        }

        public static class HmacSha256
        {
            #region Static Methods

            /// <summary>
            ///     Using HMAC SHA256 algorithm to hash input text.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="key"></param>
            /// <returns></returns>
            public static string Hash(string text,
                ref byte[] key)
            {
                return CommonHmacHash("HMACSHA256", ref key, text);
            }

            /// <summary>
            ///     Using HMAC SHA256 algorithm to hash input text with provided salt key or auto generate salt key. Default salt key
            ///     size was 6.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="key"></param>
            /// <param name="salt"></param>
            /// <param name="saltSize"></param>
            /// <returns></returns>
            public static string Hash(string text,
                ref byte[] key,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                return Hash($"{text}{salt}", ref key);
            }

            #endregion
        }

        public static class HmacSha384
        {
            #region Static Methods

            /// <summary>
            ///     Using HMAC SHA384 algorithm to hash input text.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="key"></param>
            /// <returns></returns>
            public static string Hash(string text,
                ref byte[] key)
            {
                return CommonHmacHash("HMACSHA384", ref key, text);
            }

            /// <summary>
            ///     Using HMAC SHA384 algorithm to hash input text with provided salt key or auto generate salt key. Default salt key
            ///     size was 6.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="key"></param>
            /// <param name="salt"></param>
            /// <param name="saltSize"></param>
            /// <returns></returns>
            public static string Hash(string text,
                ref byte[] key,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                return Hash($"{text}{salt}", ref key);
            }

            #endregion
        }

        public static class HmacSha512
        {
            #region Static Methods

            /// <summary>
            ///     Using HMAC SHA512 algorithm to hash input text.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="key"></param>
            /// <returns></returns>
            public static string Hash(string text,
                ref byte[] key)
            {
                return CommonHmacHash("HMACSHA512", ref key, text);
            }

            /// <summary>
            ///     Using HMAC SHA512 algorithm to hash input text with provided salt key or auto generate salt key. Default salt key
            ///     size was 6.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="key"></param>
            /// <param name="salt"></param>
            /// <param name="saltSize"></param>
            /// <returns></returns>
            public static string Hash(string text,
                ref byte[] key,
                ref string salt,
                int saltSize = 6)
            {
                if (string.IsNullOrEmpty(salt))
                {
                    salt = CreateSaltKey(saltSize);
                }

                return Hash($"{text}{salt}", ref key);
            }

            #endregion
        }

        #endregion
    }
}
