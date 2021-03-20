using System;
using System.Security.Cryptography;
using System.Text;
using Modular.NET.Core.Managers;
using Modular.NET.Tests.Utilities;
using Xunit;

namespace Modular.NET.Core.Tests.Managers
{
    public class HashManagerTests
    {
        #region Static Fields and Constants

        private const int _TestRandomRound = 10;

        #endregion

        #region Methods

        [Fact]
        public void HashManager_MD5_Hash()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var hashedRandomValue = HashManager.MD5.Hash(randomValue);

                string expectedHashed;
                using (var crypto = MD5.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(randomValue));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_MD5_HashWithSalt()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var salt = "";
                var hashedRandomValue = HashManager.MD5.Hash(randomValue, ref salt);

                string expectedHashed;
                using (var crypto = MD5.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{randomValue}{salt}"));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_SHA1_Hash()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var hashedRandomValue = HashManager.Sha1.Hash(randomValue);

                string expectedHashed;
                using (var crypto = SHA1.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(randomValue));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_SHA1_HashWithSalt()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var salt = "";
                var hashedRandomValue = HashManager.Sha1.Hash(randomValue, ref salt);

                string expectedHashed;
                using (var crypto = SHA1.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{randomValue}{salt}"));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_SHA256_Hash()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var hashedRandomValue = HashManager.Sha256.Hash(randomValue);

                string expectedHashed;
                using (var crypto = SHA256.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(randomValue));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_SHA256_HashWithSalt()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var salt = "";
                var hashedRandomValue = HashManager.Sha256.Hash(randomValue, ref salt);

                string expectedHashed;
                using (var crypto = SHA256.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{randomValue}{salt}"));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_SHA384_Hash()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var hashedRandomValue = HashManager.Sha384.Hash(randomValue);

                string expectedHashed;
                using (var crypto = SHA384.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(randomValue));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_SHA384_HashWithSalt()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var salt = "";
                var hashedRandomValue = HashManager.Sha384.Hash(randomValue, ref salt);

                string expectedHashed;
                using (var crypto = SHA384.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{randomValue}{salt}"));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_SHA512_Hash()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var hashedRandomValue = HashManager.Sha512.Hash(randomValue);

                string expectedHashed;
                using (var crypto = SHA512.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(randomValue));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_SHA512_HashWithSalt()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var salt = "";
                var hashedRandomValue = HashManager.Sha512.Hash(randomValue, ref salt);

                string expectedHashed;
                using (var crypto = SHA512.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{randomValue}{salt}"));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_SHA1Managed_Hash()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var hashedRandomValue = HashManager.Sha1Managed.Hash(randomValue);

                string expectedHashed;
                using (var crypto = SHA1.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(randomValue));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_SHA1Managed_HashWithSalt()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var salt = "";
                var hashedRandomValue = HashManager.Sha1Managed.Hash(randomValue, ref salt);

                string expectedHashed;
                using (var crypto = SHA1.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{randomValue}{salt}"));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_SHA256Managed_Hash()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var hashedRandomValue = HashManager.Sha256Managed.Hash(randomValue);

                string expectedHashed;
                using (var crypto = SHA256.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(randomValue));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_SHA256Managed_HashWithSalt()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var salt = "";
                var hashedRandomValue = HashManager.Sha256Managed.Hash(randomValue, ref salt);

                string expectedHashed;
                using (var crypto = SHA256.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{randomValue}{salt}"));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_SHA384Managed_Hash()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var hashedRandomValue = HashManager.Sha384Managed.Hash(randomValue);

                string expectedHashed;
                using (var crypto = SHA384.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(randomValue));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_SHA384Managed_HashWithSalt()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var salt = "";
                var hashedRandomValue = HashManager.Sha384Managed.Hash(randomValue, ref salt);

                string expectedHashed;
                using (var crypto = SHA384.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{randomValue}{salt}"));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_SHA512Managed_Hash()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var hashedRandomValue = HashManager.Sha512Managed.Hash(randomValue);

                string expectedHashed;
                using (var crypto = SHA512.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(randomValue));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_SHA512Managed_HashWithSalt()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var salt = "";
                var hashedRandomValue = HashManager.Sha512Managed.Hash(randomValue, ref salt);

                string expectedHashed;
                using (var crypto = SHA512.Create())
                {
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{randomValue}{salt}"));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_HMACMD5_Hash()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                byte[] key = null;
                var hashedRandomValue = HashManager.HmacMD5.Hash(randomValue, ref key);

                string expectedHashed;
                using (var crypto = HMAC.Create("HMACMD5"))
                {
                    crypto.Key = key;
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(randomValue));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_HMACMD5_HashWithSalt()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var salt = "";
                byte[] key = null;
                var hashedRandomValue = HashManager.HmacMD5.Hash(randomValue, ref key, ref salt);

                string expectedHashed;
                using (var crypto = HMAC.Create("HMACMD5"))
                {
                    crypto.Key = key;
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{randomValue}{salt}"));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_HMACMD5_Hash_RandomKey()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var key = HashManager.GenerateHashedKey(Generator.RandomInt(1, 128));
                var hashedRandomValue = HashManager.HmacMD5.Hash(randomValue, ref key);

                string expectedHashed;
                using (var crypto = HMAC.Create("HMACMD5"))
                {
                    crypto.Key = key;
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(randomValue));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_HMACSHA1_Hash()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                byte[] key = null;
                var hashedRandomValue = HashManager.HmacSha1.Hash(randomValue, ref key);

                string expectedHashed;
                using (var crypto = HMAC.Create("HMACSHA1"))
                {
                    crypto.Key = key;
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(randomValue));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_HMACSHA1_HashWithSalt()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var salt = "";
                byte[] key = null;
                var hashedRandomValue = HashManager.HmacSha1.Hash(randomValue, ref key, ref salt);

                string expectedHashed;
                using (var crypto = HMAC.Create("HMACSHA1"))
                {
                    crypto.Key = key;
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{randomValue}{salt}"));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_HMACSHA1_Hash_RandomKey()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var key = HashManager.GenerateHashedKey(Generator.RandomInt(1, 128));
                var hashedRandomValue = HashManager.HmacSha1.Hash(randomValue, ref key);

                string expectedHashed;
                using (var crypto = HMAC.Create("HMACSHA1"))
                {
                    crypto.Key = key;
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(randomValue));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_HMACSHA256_Hash()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                byte[] key = null;
                var hashedRandomValue = HashManager.HmacSha256.Hash(randomValue, ref key);

                string expectedHashed;
                using (var crypto = HMAC.Create("HMACSHA256"))
                {
                    crypto.Key = key;
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(randomValue));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_HMACSHA256_HashWithSalt()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var salt = "";
                byte[] key = null;
                var hashedRandomValue = HashManager.HmacSha256.Hash(randomValue, ref key, ref salt);

                string expectedHashed;
                using (var crypto = HMAC.Create("HMACSHA256"))
                {
                    crypto.Key = key;
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{randomValue}{salt}"));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_HMACSHA256_Hash_RandomKey()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var key = HashManager.GenerateHashedKey(Generator.RandomInt(1, 128));
                var hashedRandomValue = HashManager.HmacSha256.Hash(randomValue, ref key);

                string expectedHashed;
                using (var crypto = HMAC.Create("HMACSHA256"))
                {
                    crypto.Key = key;
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(randomValue));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_HMACSHA384_Hash()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                byte[] key = null;
                var hashedRandomValue = HashManager.HmacSha384.Hash(randomValue, ref key);

                string expectedHashed;
                using (var crypto = HMAC.Create("HMACSHA384"))
                {
                    crypto.Key = key;
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(randomValue));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_HMACSHA384_HashWithSalt()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var salt = "";
                byte[] key = null;
                var hashedRandomValue = HashManager.HmacSha384.Hash(randomValue, ref key, ref salt);

                string expectedHashed;
                using (var crypto = HMAC.Create("HMACSHA384"))
                {
                    crypto.Key = key;
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{randomValue}{salt}"));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_HMACSHA384_Hash_RandomKey()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var key = HashManager.GenerateHashedKey(Generator.RandomInt(1, 128));
                var hashedRandomValue = HashManager.HmacSha384.Hash(randomValue, ref key);

                string expectedHashed;
                using (var crypto = HMAC.Create("HMACSHA384"))
                {
                    crypto.Key = key;
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(randomValue));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_HMACSHA512_Hash()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                byte[] key = null;
                var hashedRandomValue = HashManager.HmacSha512.Hash(randomValue, ref key);

                string expectedHashed;
                using (var crypto = HMAC.Create("HMACSHA512"))
                {
                    crypto.Key = key;
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(randomValue));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_HMACSHA512_HashWithSalt()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var salt = "";
                byte[] key = null;
                var hashedRandomValue = HashManager.HmacSha512.Hash(randomValue, ref key, ref salt);

                string expectedHashed;
                using (var crypto = HMAC.Create("HMACSHA512"))
                {
                    crypto.Key = key;
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes($"{randomValue}{salt}"));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        [Fact]
        public void HashManager_HMACSHA512_Hash_RandomKey()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var key = HashManager.GenerateHashedKey(Generator.RandomInt(1, 128));
                var hashedRandomValue = HashManager.HmacSha512.Hash(randomValue, ref key);

                string expectedHashed;
                using (var crypto = HMAC.Create("HMACSHA512"))
                {
                    crypto.Key = key;
                    var hashed = crypto.ComputeHash(Encoding.UTF8.GetBytes(randomValue));
                    expectedHashed = BitConverter.ToString(hashed)
                        .Replace("-", string.Empty);
                }

                Assert.Equal(hashedRandomValue, expectedHashed);
            }
        }

        #endregion
    }
}
