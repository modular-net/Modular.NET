using System;
using Modular.NET.Tests.Utilities;
using Xunit;

namespace Modular.NET.Core.Tests.Extensions
{
    public class StringExtensionTests
    {
        #region Static Fields and Constants

        private const int _TestRandomRound = 10;

        #endregion

        #region Methods

        [Fact]
        public void StringExtension_GenerateRandomString_NoPrefer()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = "".GenerateRandomString(Generator.RandomInt());
                Assert.Matches(@"^[0-9a-zA-Z]+$", randomValue);
            }
        }

        [Fact]
        public void StringExtension_GenerateRandomString_NumberOnly()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = "".GenerateRandomString(Generator.RandomInt(), true);
                Assert.Matches(@"^[0-9]+$", randomValue);
            }
        }

        [Fact]
        public void StringExtension_GenerateRandomString_LowercaseOnly()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = "".GenerateRandomString(Generator.RandomInt(), lowercase: true);
                Assert.Matches(@"^[a-z]+$", randomValue);
            }
        }

        [Fact]
        public void StringExtension_GenerateRandomString_UppercaseOnly()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = "".GenerateRandomString(Generator.RandomInt(), uppercase: true);
                Assert.Matches(@"^[A-Z]+$", randomValue);
            }
        }

        [Fact]
        public void StringExtension_GenerateRandomString_WithAdditionalCharacter()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = "".GenerateRandomString(Generator.RandomInt(), true, true, true, " -_");
                Assert.Matches(@"^[0-9a-zA-Z_\-\s]+$", randomValue);
            }
        }

        [Fact]
        public void StringExtension_CheckLuhn()
        {
            Assert.True("79927398713".CheckLuhn());
            Assert.False("79927398719".CheckLuhn());
            Assert.False("".CheckLuhn());
            Assert.False("a79927398713".CheckLuhn());
        }

        [Fact]
        public void StringExtension_Pad()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomLength = Generator.RandomInt();
                var randomValue = Generator.RandomString();
                var pad = randomValue.Pad(randomLength);
                Assert.Equal(Math.Max(randomLength, randomValue.Length), pad.Length);
                if (randomLength > randomValue.Length)
                {
                    Assert.StartsWith(" ", pad);
                }
            }
        }

        [Fact]
        public void StringExtension_Pad_Right()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomLength = Generator.RandomInt();
                var randomValue = Generator.RandomString();
                var pad = randomValue.Pad(randomLength, paddingLeft: false);
                Assert.Equal(Math.Max(randomLength, randomValue.Length), pad.Length);
                if (randomLength > randomValue.Length)
                {
                    Assert.EndsWith(" ", pad);
                }
            }
        }

        [Fact]
        public void StringExtension_Pad_EmptyString()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomLength = Generator.RandomInt();
                Assert.Equal(randomLength, "".Pad(randomLength)
                    .Length);
            }
        }

        [Fact]
        public void StringExtension_Pad_StringLengthLongerThanParamLength()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomValue = Generator.RandomString();
                var randomLength = Generator.RandomInt(1, randomValue.Length);
                Assert.Equal(randomValue.Length, randomValue.Pad(randomLength)
                    .Length);
            }
        }

        #endregion
    }
}
