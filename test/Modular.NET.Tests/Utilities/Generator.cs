using System;
using System.Linq;
using System.Security.Cryptography;

namespace Modular.NET.Tests.Utilities
{
    public static class Generator
    {
        #region Static Fields and Constants

        private static readonly Random _Seed = new Random();

        private static readonly Random _Random = new Random(_Seed.Next());

        #endregion

        #region Static Methods

        public static bool RandomBoolean()
        {
            return RandomNumberGenerator.GetInt32(10, 100) % 2 == 0;
        }

        public static byte RandomByte()
        {
            return RandomBytes()[0];
        }

        public static byte[] RandomBytes(int size = 32)
        {
            if (size < 1)
            {
                size = RandomInt(1, 64);
            }

            var buffer = new byte[size];
            _Random.NextBytes(buffer);
            return buffer;
        }

        public static DateTime RandomDateTime()
        {
            return new DateTime(2000, 1, 1).AddDays(RandomInt(10, 10000))
                .AddHours(RandomInt(0, 24))
                .AddMinutes(RandomInt(0, 60));
        }

        public static decimal RandomDecimal()
        {
            return Convert.ToDecimal(_Random.NextDouble());
        }

        public static double RandomDouble()
        {
            return _Random.NextDouble();
        }

        public static float RandomFloat()
        {
            return Convert.ToSingle(_Random.NextDouble());
        }

        public static int RandomInt(int min = 10,
            int max = 1000)
        {
            return _Random.Next(min, max);
        }

        public static long RandomLong(int min = 10,
            int max = 1000)
        {
            return Convert.ToInt64(_Random.Next(min, max));
        }

        public static short RandomShort(int min = 10,
            int max = 1000)
        {
            if (min < short.MinValue)
            {
                min = short.MinValue;
            }

            if (max > short.MaxValue)
            {
                max = short.MaxValue;
            }

            return Convert.ToInt16(_Random.Next(min, max));
        }

        public static string RandomString()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var ret = new string(Enumerable.Repeat(chars, _Random.Next(10, 100))
                .Select(x => x[_Random.Next(x.Length)])
                .ToArray());
            return ret;
        }

        public static object RandomObject()
        {
            switch (RandomInt(0, 11))
            {
                case 0:
                    return RandomBoolean();
                case 1:
                    return RandomByte();
                case 2:
                    return RandomBytes();
                case 3:
                    return RandomDateTime();
                case 4:
                    return RandomDecimal();
                case 5:
                    return RandomDouble();
                case 6:
                    return RandomFloat();
                case 7:
                    return RandomInt();
                case 8:
                    return RandomLong();
                case 9:
                    return RandomShort();
                default:
                    return RandomString();
            }
        }

        #endregion
    }
}
