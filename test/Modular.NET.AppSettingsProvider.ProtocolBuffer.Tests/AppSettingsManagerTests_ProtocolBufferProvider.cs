using System;
using System.IO;
using System.Threading.Tasks;
using Modular.NET.AppSettingsProvider.ProtocolBuffer.Configurations;
using Modular.NET.AppSettingsProvider.ProtocolBuffer.Tests.TestMaterials.Enums;
using Modular.NET.Core;
using Modular.NET.Core.Interfaces;
using Modular.NET.Core.Managers;
using Modular.NET.Tests.Attributes;
using Modular.NET.Tests.Utilities;
using Xunit;

namespace Modular.NET.AppSettingsProvider.ProtocolBuffer.Tests
{
    [TestCaseOrderer("Modular.NET.Tests.Orderers.TestPriorityOrderer", "Modular.NET.Tests")]
    [Collection("AppSettingsManager")]
    // ReSharper disable once InconsistentNaming
    public class AppSettingsManagerTests_ProtocolBufferProvider
    {
        #region Static Fields and Constants

        private const int _TestRandomRound = 10;

        #endregion

        #region Constructors

        static AppSettingsManagerTests_ProtocolBufferProvider()
        {
            if (File.Exists(ProtocolBufferConfiguration.Location))
            {
                File.Delete(ProtocolBufferConfiguration.Location);
            }

            Engine.Unregister<IAppSettingsProvider>();
            Engine.Register<IAppSettingsProvider, ProtocolBufferProvider>();
            ProtocolBufferConfiguration.EncryptionKeyPair = EncryptionManager.Aes.GenerateKeyPair();
            AppSettingsManager.ResetProvider();
        }

        #endregion

        #region Methods

        [Fact]
        public void AppSettingsManager_FileExists()
        {
            var randomKey = Generator.RandomString();
            var randomValue = Generator.RandomBoolean();

            Assert.True(AppSettingsManager.SetBoolean(randomKey, randomValue));

            Assert.True(File.Exists(ProtocolBufferConfiguration.Location));
        }

        [Fact]
        [TestPriority(1000)]
        public void AppSettingsManager_ClearSettings()
        {
            var randomKey = Generator.RandomString();
            var randomValue = Generator.RandomString();

            Assert.True(AppSettingsManager.SetString(randomKey, randomValue));

            Assert.Equal(randomValue, AppSettingsManager.GetString(randomKey));

            Assert.True(AppSettingsManager.ClearSettings());

            Assert.NotEqual(randomValue, AppSettingsManager.GetString(randomKey));
        }

        [Fact]
        [TestPriority(1001)]
        public async Task AppSettingsManager_ClearSettingsAsync()
        {
            var randomKey = Generator.RandomString();
            var randomValue = Generator.RandomString();

            Assert.True(await AppSettingsManager.SetStringAsync(randomKey, randomValue));

            Assert.Equal(randomValue, await AppSettingsManager.GetStringAsync(randomKey));

            Assert.True(await AppSettingsManager.ClearSettingsAsync());

            Assert.NotEqual(randomValue, await AppSettingsManager.GetStringAsync(randomKey));
        }

        [Fact]
        public void AppSettingsManager_Boolean_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomBoolean();

                Assert.Null(AppSettingsManager.GetBoolean(randomKey));

                Assert.True(AppSettingsManager.SetBoolean(randomKey, randomValue));

                Assert.Equal(randomValue, AppSettingsManager.GetBoolean(randomKey));
            }
        }

        [Fact]
        public void AppSettingsManager_Boolean_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomBoolean();

                Assert.Null(AppSettingsManager.GetBoolean(randomKey, true));

                Assert.True(AppSettingsManager.SetBoolean(randomKey, randomValue, true));

                Assert.Equal(randomValue, AppSettingsManager.GetBoolean(randomKey, true));
            }
        }

        [Fact]
        public void AppSettingsManager_Boolean_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomBoolean();

                Assert.Null(AppSettingsManager.GetBoolean(randomKey));

                Assert.Equal(randomValue, AppSettingsManager.GetBoolean(randomKey, randomValue, false));
            }
        }

        [Fact]
        public void AppSettingsManager_Byte_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomByte();

                Assert.Null(AppSettingsManager.GetByte(randomKey));

                Assert.True(AppSettingsManager.SetByte(randomKey, randomValue));

                Assert.Equal(randomValue, AppSettingsManager.GetByte(randomKey));
            }
        }

        [Fact]
        public void AppSettingsManager_Byte_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomByte();

                Assert.Null(AppSettingsManager.GetByte(randomKey, true));

                Assert.True(AppSettingsManager.SetByte(randomKey, randomValue, true));

                Assert.Equal(randomValue, AppSettingsManager.GetByte(randomKey, true));
            }
        }

        [Fact]
        public void AppSettingsManager_Byte_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomByte();

                Assert.Null(AppSettingsManager.GetByte(randomKey));

                Assert.Equal(randomValue, AppSettingsManager.GetByte(randomKey, randomValue));
            }
        }

        [Fact]
        public void AppSettingsManager_Bytes_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomBytes();

                Assert.Null(AppSettingsManager.GetBytes(randomKey));

                Assert.True(AppSettingsManager.SetBytes(randomKey, randomValue));

                Assert.Equal(randomValue, AppSettingsManager.GetBytes(randomKey));
            }
        }

        [Fact]
        public void AppSettingsManager_Bytes_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomBytes();

                Assert.Null(AppSettingsManager.GetBytes(randomKey, true));

                Assert.True(AppSettingsManager.SetBytes(randomKey, randomValue, true));

                Assert.Equal(randomValue, AppSettingsManager.GetBytes(randomKey, true));
            }
        }

        [Fact]
        public void AppSettingsManager_Bytes_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomBytes();

                Assert.Null(AppSettingsManager.GetBytes(randomKey));

                Assert.Equal(randomValue, AppSettingsManager.GetBytes(randomKey, randomValue));
            }
        }

        [Fact]
        public void AppSettingsManager_DateTime_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomDateTime();

                Assert.Null(AppSettingsManager.GetDateTime(randomKey));

                Assert.True(AppSettingsManager.SetDateTime(randomKey, randomValue));

                Assert.Equal(randomValue, AppSettingsManager.GetDateTime(randomKey));
            }
        }

        [Fact]
        public void AppSettingsManager_DateTime_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomDateTime();

                Assert.Null(AppSettingsManager.GetDateTime(randomKey, true));

                Assert.True(AppSettingsManager.SetDateTime(randomKey, randomValue, true));

                Assert.Equal(randomValue, AppSettingsManager.GetDateTime(randomKey, true));
            }
        }

        [Fact]
        public void AppSettingsManager_DateTime_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomDateTime();

                Assert.Null(AppSettingsManager.GetDateTime(randomKey));

                Assert.Equal(randomValue, AppSettingsManager.GetDateTime(randomKey, randomValue));
            }
        }

        [Fact]
        public void AppSettingsManager_Decimal_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomDecimal();

                Assert.Null(AppSettingsManager.GetDecimal(randomKey));

                Assert.True(AppSettingsManager.SetDecimal(randomKey, randomValue));

                Assert.Equal(randomValue, AppSettingsManager.GetDecimal(randomKey));
            }
        }

        [Fact]
        public void AppSettingsManager_Decimal_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomDecimal();

                Assert.Null(AppSettingsManager.GetDecimal(randomKey, true));

                Assert.True(AppSettingsManager.SetDecimal(randomKey, randomValue, true));

                Assert.Equal(randomValue, AppSettingsManager.GetDecimal(randomKey, true));
            }
        }

        [Fact]
        public void AppSettingsManager_Decimal_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomDecimal();

                Assert.Null(AppSettingsManager.GetDecimal(randomKey));

                Assert.Equal(randomValue, AppSettingsManager.GetDecimal(randomKey, randomValue));
            }
        }

        [Fact]
        public void AppSettingsManager_Double_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomDouble();

                Assert.Null(AppSettingsManager.GetDouble(randomKey));

                Assert.True(AppSettingsManager.SetDouble(randomKey, randomValue));

                Assert.Equal(randomValue, AppSettingsManager.GetDouble(randomKey));
            }
        }

        [Fact]
        public void AppSettingsManager_Double_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomDouble();

                Assert.Null(AppSettingsManager.GetDouble(randomKey, true));

                Assert.True(AppSettingsManager.SetDouble(randomKey, randomValue, true));

                Assert.Equal(randomValue, AppSettingsManager.GetDouble(randomKey, true));
            }
        }

        [Fact]
        public void AppSettingsManager_Double_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomDouble();

                Assert.Null(AppSettingsManager.GetDouble(randomKey));

                Assert.Equal(randomValue, AppSettingsManager.GetDouble(randomKey, randomValue));
            }
        }

        [Fact]
        public void AppSettingsManager_Enum_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomDefaultValue = (EnumGender) Generator.RandomInt(0, Enum.GetValues(typeof(EnumGender))
                    .Length);
                var randomValue = (EnumGender) Generator.RandomInt(0, Enum.GetValues(typeof(EnumGender))
                    .Length);

                Assert.Equal(randomDefaultValue, AppSettingsManager.GetEnum(randomKey, randomDefaultValue));

                Assert.True(AppSettingsManager.SetEnum(randomKey, randomValue));

                Assert.Equal(randomValue, AppSettingsManager.GetEnum(randomKey, randomDefaultValue));
            }
        }

        [Fact]
        public void AppSettingsManager_Enum_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomDefaultValue = (EnumGender) Generator.RandomInt(0, Enum.GetValues(typeof(EnumGender))
                    .Length);
                var randomValue = (EnumGender) Generator.RandomInt(0, Enum.GetValues(typeof(EnumGender))
                    .Length);

                Assert.Equal(randomDefaultValue, AppSettingsManager.GetEnum(randomKey, randomDefaultValue, true));

                Assert.True(AppSettingsManager.SetEnum(randomKey, randomValue, true));

                Assert.Equal(randomValue, AppSettingsManager.GetEnum(randomKey, randomDefaultValue, true));
            }
        }

        [Fact]
        public void AppSettingsManager_Float_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomFloat();

                Assert.Null(AppSettingsManager.GetFloat(randomKey));

                Assert.True(AppSettingsManager.SetFloat(randomKey, randomValue));

                Assert.Equal(randomValue, AppSettingsManager.GetFloat(randomKey));
            }
        }

        [Fact]
        public void AppSettingsManager_Float_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomFloat();

                Assert.Null(AppSettingsManager.GetFloat(randomKey, true));

                Assert.True(AppSettingsManager.SetFloat(randomKey, randomValue, true));

                Assert.Equal(randomValue, AppSettingsManager.GetFloat(randomKey, true));
            }
        }

        [Fact]
        public void AppSettingsManager_Float_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomFloat();

                Assert.Null(AppSettingsManager.GetFloat(randomKey));

                Assert.Equal(randomValue, AppSettingsManager.GetFloat(randomKey, randomValue));
            }
        }

        [Fact]
        public void AppSettingsManager_Int_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomInt();

                Assert.Null(AppSettingsManager.GetInt(randomKey));

                Assert.True(AppSettingsManager.SetInt(randomKey, randomValue));

                Assert.Equal(randomValue, AppSettingsManager.GetInt(randomKey));
            }
        }

        [Fact]
        public void AppSettingsManager_Int_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomInt();

                Assert.Null(AppSettingsManager.GetInt(randomKey, true));

                Assert.True(AppSettingsManager.SetInt(randomKey, randomValue, true));

                Assert.Equal(randomValue, AppSettingsManager.GetInt(randomKey, true));
            }
        }

        [Fact]
        public void AppSettingsManager_Int_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomInt();

                Assert.Null(AppSettingsManager.GetInt(randomKey));

                Assert.Equal(randomValue, AppSettingsManager.GetInt(randomKey, randomValue));
            }
        }

        [Fact]
        public void AppSettingsManager_Long_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomLong();

                Assert.Null(AppSettingsManager.GetLong(randomKey));

                Assert.True(AppSettingsManager.SetLong(randomKey, randomValue));

                Assert.Equal(randomValue, AppSettingsManager.GetLong(randomKey));
            }
        }

        [Fact]
        public void AppSettingsManager_Long_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomLong();

                Assert.Null(AppSettingsManager.GetLong(randomKey, true));

                Assert.True(AppSettingsManager.SetLong(randomKey, randomValue, true));

                Assert.Equal(randomValue, AppSettingsManager.GetLong(randomKey, true));
            }
        }

        [Fact]
        public void AppSettingsManager_Long_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomLong();

                Assert.Null(AppSettingsManager.GetLong(randomKey));

                Assert.Equal(randomValue, AppSettingsManager.GetLong(randomKey, randomValue));
            }
        }

        [Fact]
        public void AppSettingsManager_Short_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomShort();

                Assert.Null(AppSettingsManager.GetShort(randomKey));

                Assert.True(AppSettingsManager.SetShort(randomKey, randomValue));

                Assert.Equal(randomValue, AppSettingsManager.GetShort(randomKey));
            }
        }

        [Fact]
        public void AppSettingsManager_Short_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomShort();

                Assert.Null(AppSettingsManager.GetShort(randomKey, true));

                Assert.True(AppSettingsManager.SetShort(randomKey, randomValue, true));

                Assert.Equal(randomValue, AppSettingsManager.GetShort(randomKey, true));
            }
        }

        [Fact]
        public void AppSettingsManager_Short_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomShort();

                Assert.Null(AppSettingsManager.GetShort(randomKey));

                Assert.Equal(randomValue, AppSettingsManager.GetShort(randomKey, randomValue));
            }
        }

        [Fact]
        public void AppSettingsManager_String_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomString();

                Assert.Null(AppSettingsManager.GetString(randomKey));

                Assert.True(AppSettingsManager.SetString(randomKey, randomValue));

                Assert.Equal(randomValue, AppSettingsManager.GetString(randomKey));
            }
        }

        [Fact]
        public void AppSettingsManager_String_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomString();

                Assert.Null(AppSettingsManager.GetString(randomKey, true));

                Assert.True(AppSettingsManager.SetString(randomKey, randomValue, true));

                Assert.Equal(randomValue, AppSettingsManager.GetString(randomKey, true));
            }
        }

        [Fact]
        public void AppSettingsManager_String_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomString();

                Assert.Null(AppSettingsManager.GetString(randomKey));

                Assert.Equal(randomValue, AppSettingsManager.GetString(randomKey, randomValue));
            }
        }

        [Fact]
        public async Task AppSettingsManager_BooleanAsync_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomBoolean();

                Assert.Null(await AppSettingsManager.GetBooleanAsync(randomKey));

                Assert.True(await AppSettingsManager.SetBooleanAsync(randomKey, randomValue));

                Assert.Equal(randomValue, await AppSettingsManager.GetBooleanAsync(randomKey));
            }
        }

        [Fact]
        public async Task AppSettingsManager_BooleanAsync_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomBoolean();

                Assert.Null(await AppSettingsManager.GetBooleanAsync(randomKey, true));

                Assert.True(await AppSettingsManager.SetBooleanAsync(randomKey, randomValue, true));

                Assert.Equal(randomValue, await AppSettingsManager.GetBooleanAsync(randomKey, true));
            }
        }

        [Fact]
        public async Task AppSettingsManager_BooleanAsync_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomBoolean();

                Assert.Null(await AppSettingsManager.GetBooleanAsync(randomKey));

                Assert.Equal(randomValue, await AppSettingsManager.GetBooleanAsync(randomKey, randomValue, false));
            }
        }

        [Fact]
        public async Task AppSettingsManager_ByteAsync_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomByte();

                Assert.Null(await AppSettingsManager.GetByteAsync(randomKey));

                Assert.True(await AppSettingsManager.SetByteAsync(randomKey, randomValue));

                Assert.Equal(randomValue, await AppSettingsManager.GetByteAsync(randomKey));
            }
        }

        [Fact]
        public async Task AppSettingsManager_ByteAsync_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomByte();

                Assert.Null(await AppSettingsManager.GetByteAsync(randomKey, true));

                Assert.True(await AppSettingsManager.SetByteAsync(randomKey, randomValue, true));

                Assert.Equal(randomValue, await AppSettingsManager.GetByteAsync(randomKey, true));
            }
        }

        [Fact]
        public async Task AppSettingsManager_ByteAsync_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomByte();

                Assert.Null(await AppSettingsManager.GetByteAsync(randomKey));

                Assert.Equal(randomValue, await AppSettingsManager.GetByteAsync(randomKey, randomValue));
            }
        }

        [Fact]
        public async Task AppSettingsManager_BytesAsync_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomBytes();

                Assert.Null(await AppSettingsManager.GetBytesAsync(randomKey));

                Assert.True(await AppSettingsManager.SetBytesAsync(randomKey, randomValue));

                Assert.Equal(randomValue, await AppSettingsManager.GetBytesAsync(randomKey));
            }
        }

        [Fact]
        public async Task AppSettingsManager_BytesAsync_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomBytes();

                Assert.Null(await AppSettingsManager.GetBytesAsync(randomKey, true));

                Assert.True(await AppSettingsManager.SetBytesAsync(randomKey, randomValue, true));

                Assert.Equal(randomValue, await AppSettingsManager.GetBytesAsync(randomKey, true));
            }
        }

        [Fact]
        public async Task AppSettingsManager_BytesAsync_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomBytes();

                Assert.Null(await AppSettingsManager.GetBytesAsync(randomKey));

                Assert.Equal(randomValue, await AppSettingsManager.GetBytesAsync(randomKey, randomValue));
            }
        }

        [Fact]
        public async Task AppSettingsManager_DateTimeAsync_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomDateTime();

                Assert.Null(await AppSettingsManager.GetDateTimeAsync(randomKey));

                Assert.True(await AppSettingsManager.SetDateTimeAsync(randomKey, randomValue));

                Assert.Equal(randomValue, await AppSettingsManager.GetDateTimeAsync(randomKey));
            }
        }

        [Fact]
        public async Task AppSettingsManager_DateTimeAsync_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomDateTime();

                Assert.Null(await AppSettingsManager.GetDateTimeAsync(randomKey, true));

                Assert.True(await AppSettingsManager.SetDateTimeAsync(randomKey, randomValue, true));

                Assert.Equal(randomValue, await AppSettingsManager.GetDateTimeAsync(randomKey, true));
            }
        }

        [Fact]
        public async Task AppSettingsManager_DateTimeAsync_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomDateTime();

                Assert.Null(await AppSettingsManager.GetDateTimeAsync(randomKey));

                Assert.Equal(randomValue, await AppSettingsManager.GetDateTimeAsync(randomKey, randomValue));
            }
        }

        [Fact]
        public async Task AppSettingsManager_DecimalAsync_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomDecimal();

                Assert.Null(await AppSettingsManager.GetDecimalAsync(randomKey));

                Assert.True(await AppSettingsManager.SetDecimalAsync(randomKey, randomValue));

                Assert.Equal(randomValue, await AppSettingsManager.GetDecimalAsync(randomKey));
            }
        }

        [Fact]
        public async Task AppSettingsManager_DecimalAsync_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomDecimal();

                Assert.Null(await AppSettingsManager.GetDecimalAsync(randomKey, true));

                Assert.True(await AppSettingsManager.SetDecimalAsync(randomKey, randomValue, true));

                Assert.Equal(randomValue, await AppSettingsManager.GetDecimalAsync(randomKey, true));
            }
        }

        [Fact]
        public async Task AppSettingsManager_DecimalAsync_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomDecimal();

                Assert.Null(await AppSettingsManager.GetDecimalAsync(randomKey));

                Assert.Equal(randomValue, await AppSettingsManager.GetDecimalAsync(randomKey, randomValue));
            }
        }

        [Fact]
        public async Task AppSettingsManager_DoubleAsync_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomDouble();

                Assert.Null(await AppSettingsManager.GetDoubleAsync(randomKey));

                Assert.True(await AppSettingsManager.SetDoubleAsync(randomKey, randomValue));

                Assert.Equal(randomValue, await AppSettingsManager.GetDoubleAsync(randomKey));
            }
        }

        [Fact]
        public async Task AppSettingsManager_DoubleAsync_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomDouble();

                Assert.Null(await AppSettingsManager.GetDoubleAsync(randomKey, true));

                Assert.True(await AppSettingsManager.SetDoubleAsync(randomKey, randomValue, true));

                Assert.Equal(randomValue, await AppSettingsManager.GetDoubleAsync(randomKey, true));
            }
        }

        [Fact]
        public async Task AppSettingsManager_DoubleAsync_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomDouble();

                Assert.Null(await AppSettingsManager.GetDoubleAsync(randomKey));

                Assert.Equal(randomValue, await AppSettingsManager.GetDoubleAsync(randomKey, randomValue));
            }
        }

        [Fact]
        public async Task AppSettingsManager_EnumAsync_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomDefaultValue = (EnumGender) Generator.RandomInt(0, Enum.GetValues(typeof(EnumGender))
                    .Length);
                var randomValue = (EnumGender) Generator.RandomInt(0, Enum.GetValues(typeof(EnumGender))
                    .Length);

                Assert.Equal(randomDefaultValue, await AppSettingsManager.GetEnumAsync(randomKey, randomDefaultValue));

                Assert.True(await AppSettingsManager.SetEnumAsync(randomKey, randomValue));

                Assert.Equal(randomValue, await AppSettingsManager.GetEnumAsync(randomKey, randomDefaultValue));
            }
        }

        [Fact]
        public async Task AppSettingsManager_EnumAsync_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomDefaultValue = (EnumGender) Generator.RandomInt(0, Enum.GetValues(typeof(EnumGender))
                    .Length);
                var randomValue = (EnumGender) Generator.RandomInt(0, Enum.GetValues(typeof(EnumGender))
                    .Length);

                Assert.Equal(randomDefaultValue,
                    await AppSettingsManager.GetEnumAsync(randomKey, randomDefaultValue, true));

                Assert.True(await AppSettingsManager.SetEnumAsync(randomKey, randomValue, true));

                Assert.Equal(randomValue, await AppSettingsManager.GetEnumAsync(randomKey, randomDefaultValue, true));
            }
        }

        [Fact]
        public async Task AppSettingsManager_FloatAsync_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomFloat();

                Assert.Null(await AppSettingsManager.GetFloatAsync(randomKey));

                Assert.True(await AppSettingsManager.SetFloatAsync(randomKey, randomValue));

                Assert.Equal(randomValue, await AppSettingsManager.GetFloatAsync(randomKey));
            }
        }

        [Fact]
        public async Task AppSettingsManager_FloatAsync_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomFloat();

                Assert.Null(await AppSettingsManager.GetFloatAsync(randomKey, true));

                Assert.True(await AppSettingsManager.SetFloatAsync(randomKey, randomValue, true));

                Assert.Equal(randomValue, await AppSettingsManager.GetFloatAsync(randomKey, true));
            }
        }

        [Fact]
        public async Task AppSettingsManager_FloatAsync_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomFloat();

                Assert.Null(await AppSettingsManager.GetFloatAsync(randomKey));

                Assert.Equal(randomValue, await AppSettingsManager.GetFloatAsync(randomKey, randomValue));
            }
        }

        [Fact]
        public async Task AppSettingsManager_IntAsync_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomInt();

                Assert.Null(await AppSettingsManager.GetIntAsync(randomKey));

                Assert.True(await AppSettingsManager.SetIntAsync(randomKey, randomValue));

                Assert.Equal(randomValue, await AppSettingsManager.GetIntAsync(randomKey));
            }
        }

        [Fact]
        public async Task AppSettingsManager_IntAsync_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomInt();

                Assert.Null(await AppSettingsManager.GetIntAsync(randomKey, true));

                Assert.True(await AppSettingsManager.SetIntAsync(randomKey, randomValue, true));

                Assert.Equal(randomValue, await AppSettingsManager.GetIntAsync(randomKey, true));
            }
        }

        [Fact]
        public async Task AppSettingsManager_IntAsync_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomInt();

                Assert.Null(await AppSettingsManager.GetIntAsync(randomKey));

                Assert.Equal(randomValue, await AppSettingsManager.GetIntAsync(randomKey, randomValue));
            }
        }

        [Fact]
        public async Task AppSettingsManager_LongAsync_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomLong();

                Assert.Null(await AppSettingsManager.GetLongAsync(randomKey));

                Assert.True(await AppSettingsManager.SetLongAsync(randomKey, randomValue));

                Assert.Equal(randomValue, await AppSettingsManager.GetLongAsync(randomKey));
            }
        }

        [Fact]
        public async Task AppSettingsManager_LongAsync_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomLong();

                Assert.Null(await AppSettingsManager.GetLongAsync(randomKey, true));

                Assert.True(await AppSettingsManager.SetLongAsync(randomKey, randomValue, true));

                Assert.Equal(randomValue, await AppSettingsManager.GetLongAsync(randomKey, true));
            }
        }

        [Fact]
        public async Task AppSettingsManager_LongAsync_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomLong();

                Assert.Null(await AppSettingsManager.GetLongAsync(randomKey));

                Assert.Equal(randomValue, await AppSettingsManager.GetLongAsync(randomKey, randomValue));
            }
        }

        [Fact]
        public async Task AppSettingsManager_ShortAsync_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomShort();

                Assert.Null(await AppSettingsManager.GetShortAsync(randomKey));

                Assert.True(await AppSettingsManager.SetShortAsync(randomKey, randomValue));

                Assert.Equal(randomValue, await AppSettingsManager.GetShortAsync(randomKey));
            }
        }

        [Fact]
        public async Task AppSettingsManager_ShortAsync_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomShort();

                Assert.Null(await AppSettingsManager.GetShortAsync(randomKey, true));

                Assert.True(await AppSettingsManager.SetShortAsync(randomKey, randomValue, true));

                Assert.Equal(randomValue, await AppSettingsManager.GetShortAsync(randomKey, true));
            }
        }

        [Fact]
        public async Task AppSettingsManager_ShortAsync_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomShort();

                Assert.Null(await AppSettingsManager.GetShortAsync(randomKey));

                Assert.Equal(randomValue, await AppSettingsManager.GetShortAsync(randomKey, randomValue));
            }
        }

        [Fact]
        public async Task AppSettingsManager_StringAsync_NoEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomString();

                Assert.Null(await AppSettingsManager.GetStringAsync(randomKey));

                Assert.True(await AppSettingsManager.SetStringAsync(randomKey, randomValue));

                Assert.Equal(randomValue, await AppSettingsManager.GetStringAsync(randomKey));
            }
        }

        [Fact]
        public async Task AppSettingsManager_StringAsync_GotEncryption()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomString();

                Assert.Null(await AppSettingsManager.GetStringAsync(randomKey, true));

                Assert.True(await AppSettingsManager.SetStringAsync(randomKey, randomValue, true));

                Assert.Equal(randomValue, await AppSettingsManager.GetStringAsync(randomKey, true));
            }
        }

        [Fact]
        public async Task AppSettingsManager_StringAsync_DefaultValue()
        {
            for (var i = 0; i < _TestRandomRound; i++)
            {
                var randomKey = Generator.RandomString();
                var randomValue = Generator.RandomString();

                Assert.Null(await AppSettingsManager.GetStringAsync(randomKey));

                Assert.Equal(randomValue, await AppSettingsManager.GetStringAsync(randomKey, randomValue));
            }
        }

        #endregion
    }

    [Collection("AppSettingsManager")]
    // ReSharper disable once InconsistentNaming
    public class AppSettingsManagerTests_ProtocolBufferProvider_NotDefaultLocation
    {
        #region Constructors

        static AppSettingsManagerTests_ProtocolBufferProvider_NotDefaultLocation()
        {
            ProtocolBufferConfiguration.Location = ".\\settings-alt.bin";

            if (File.Exists(ProtocolBufferConfiguration.Location))
            {
                File.Delete(ProtocolBufferConfiguration.Location);
            }

            Engine.Unregister<IAppSettingsProvider>();
            Engine.Register<IAppSettingsProvider, ProtocolBufferProvider>();
            ProtocolBufferConfiguration.EncryptionKeyPair = EncryptionManager.Aes.GenerateKeyPair();
            AppSettingsManager.ResetProvider();
        }

        #endregion

        #region Methods

        [Fact]
        public void AppSettingsManager_FileExists()
        {
            var randomKey = Generator.RandomString();
            var randomValue = Generator.RandomBoolean();

            Assert.True(AppSettingsManager.SetBoolean(randomKey, randomValue));

            Assert.True(File.Exists(ProtocolBufferConfiguration.Location));
        }

        #endregion
    }
}
