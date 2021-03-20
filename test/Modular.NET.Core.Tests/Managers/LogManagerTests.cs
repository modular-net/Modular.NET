using System;
using Modular.NET.Core.Managers;
using Modular.NET.Core.Tests.TestUtilities;
using Modular.NET.Tests.Utilities;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.TestCorrelator;
using Xunit;

namespace Modular.NET.Core.Tests.Managers
{
    public class LogManagerTests
    {
        #region Constructors

        public LogManagerTests()
        {
            LogManager.GetConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.TestCorrelator();
        }

        #endregion

        #region Methods

        [Fact]
        public void LogManager_WriteVerbose()
        {
            var randomString = Generator.RandomString();

            using var context = TestCorrelator.CreateContext();
            LogManager.Verbose(randomString);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                Assert.True(item.Level == LogEventLevel.Verbose);
                Assert.Equal(randomString, item.RenderMessage());
            });
        }

        [Fact]
        public void LogManager_WriteVerbose_WithException()
        {
            var exception = new Exception("TestException");
            var randomString = Generator.RandomString();

            using var context = TestCorrelator.CreateContext();
            LogManager.Verbose(exception, randomString);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = randomString;
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Verbose);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteVerbose_WithMultiplePropertyValues()
        {
            var now = DateTime.Now;
            var guid = Guid.NewGuid();
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Verbose("[{Now:o}] {Guid} - Processed {@Coordinate} in {RandomInt:000} ms.", now, guid,
                coordinate, randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] {guid} - Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Verbose);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteVerbose_WithMultiplePropertyValuesWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;
            var guid = Guid.NewGuid();
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Verbose(exception, "[{Now:o}] {Guid} - Processed {@Coordinate} in {RandomInt:000} ms.", now,
                guid, coordinate, randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] {guid} - Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Verbose);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteVerbose_WithThreePropertyValues()
        {
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Verbose("[{Now:o}] Processed {@Coordinate} in {RandomInt:000} ms.", now, coordinate,
                randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Verbose);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteVerbose_WithThreePropertyValuesWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Verbose(exception, "[{Now:o}] Processed {@Coordinate} in {RandomInt:000} ms.", now,
                coordinate, randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Verbose);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteVerbose_WithTwoPropertyValues()
        {
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };

            using var context = TestCorrelator.CreateContext();
            LogManager.Verbose("[{Now:o}] Processed {@Coordinate}.", now, coordinate);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)}.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Verbose);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteVerbose_WithTwoPropertyValuesWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };

            using var context = TestCorrelator.CreateContext();
            LogManager.Verbose(exception, "[{Now:o}] Processed {@Coordinate}.", now, coordinate);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)}.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Verbose);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteVerbose_WithOnePropertyValue()
        {
            var now = DateTime.Now;

            using var context = TestCorrelator.CreateContext();
            LogManager.Verbose("[{Now:o}] Processed.", now);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Verbose);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteVerbose_WithOnePropertyValueWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;

            using var context = TestCorrelator.CreateContext();
            LogManager.Verbose(exception, "[{Now:o}] Processed.", now);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Verbose);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteDebug()
        {
            var randomString = Generator.RandomString();

            using var context = TestCorrelator.CreateContext();
            LogManager.Debug(randomString);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                Assert.True(item.Level == LogEventLevel.Debug);
                Assert.Equal(randomString, item.RenderMessage());
            });
        }

        [Fact]
        public void LogManager_WriteDebug_WithException()
        {
            var exception = new Exception("TestException");
            var randomString = Generator.RandomString();

            using var context = TestCorrelator.CreateContext();
            LogManager.Debug(exception, randomString);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = randomString;
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Debug);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteDebug_WithMultiplePropertyValues()
        {
            var now = DateTime.Now;
            var guid = Guid.NewGuid();
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Debug("[{Now:o}] {Guid} - Processed {@Coordinate} in {RandomInt:000} ms.", now, guid,
                coordinate, randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] {guid} - Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Debug);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteDebug_WithMultiplePropertyValuesWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;
            var guid = Guid.NewGuid();
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Debug(exception, "[{Now:o}] {Guid} - Processed {@Coordinate} in {RandomInt:000} ms.", now,
                guid, coordinate, randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] {guid} - Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Debug);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteDebug_WithThreePropertyValues()
        {
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Debug("[{Now:o}] Processed {@Coordinate} in {RandomInt:000} ms.", now, coordinate,
                randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Debug);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteDebug_WithThreePropertyValuesWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Debug(exception, "[{Now:o}] Processed {@Coordinate} in {RandomInt:000} ms.", now, coordinate,
                randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Debug);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteDebug_WithTwoPropertyValues()
        {
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };

            using var context = TestCorrelator.CreateContext();
            LogManager.Debug("[{Now:o}] Processed {@Coordinate}.", now, coordinate);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)}.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Debug);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteDebug_WithTwoPropertyValuesWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };

            using var context = TestCorrelator.CreateContext();
            LogManager.Debug(exception, "[{Now:o}] Processed {@Coordinate}.", now, coordinate);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)}.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Debug);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteDebug_WithOnePropertyValue()
        {
            var now = DateTime.Now;

            using var context = TestCorrelator.CreateContext();
            LogManager.Debug("[{Now:o}] Processed.", now);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Debug);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteDebug_WithOnePropertyValueWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;

            using var context = TestCorrelator.CreateContext();
            LogManager.Debug(exception, "[{Now:o}] Processed.", now);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Debug);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteInformation()
        {
            var randomString = Generator.RandomString();

            using var context = TestCorrelator.CreateContext();
            LogManager.Information(randomString);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                Assert.True(item.Level == LogEventLevel.Information);
                Assert.Equal(randomString, item.RenderMessage());
            });
        }

        [Fact]
        public void LogManager_WriteInformation_WithException()
        {
            var exception = new Exception("TestException");
            var randomString = Generator.RandomString();

            using var context = TestCorrelator.CreateContext();
            LogManager.Information(exception, randomString);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = randomString;
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Information);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteInformation_WithMultiplePropertyValues()
        {
            var now = DateTime.Now;
            var guid = Guid.NewGuid();
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Information("[{Now:o}] {Guid} - Processed {@Coordinate} in {RandomInt:000} ms.", now, guid,
                coordinate, randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] {guid} - Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Information);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteInformation_WithMultiplePropertyValuesWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;
            var guid = Guid.NewGuid();
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Information(exception, "[{Now:o}] {Guid} - Processed {@Coordinate} in {RandomInt:000} ms.",
                now, guid, coordinate, randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] {guid} - Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Information);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteInformation_WithThreePropertyValues()
        {
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Information("[{Now:o}] Processed {@Coordinate} in {RandomInt:000} ms.", now, coordinate,
                randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Information);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteInformation_WithThreePropertyValuesWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Information(exception, "[{Now:o}] Processed {@Coordinate} in {RandomInt:000} ms.", now,
                coordinate, randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Information);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteInformation_WithTwoPropertyValues()
        {
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };

            using var context = TestCorrelator.CreateContext();
            LogManager.Information("[{Now:o}] Processed {@Coordinate}.", now, coordinate);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)}.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Information);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteInformation_WithTwoPropertyValuesWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };

            using var context = TestCorrelator.CreateContext();
            LogManager.Information(exception, "[{Now:o}] Processed {@Coordinate}.", now, coordinate);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)}.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Information);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteInformation_WithOnePropertyValue()
        {
            var now = DateTime.Now;

            using var context = TestCorrelator.CreateContext();
            LogManager.Information("[{Now:o}] Processed.", now);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Information);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteInformation_WithOnePropertyValueWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;

            using var context = TestCorrelator.CreateContext();
            LogManager.Information(exception, "[{Now:o}] Processed.", now);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Information);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteWarning()
        {
            var randomString = Generator.RandomString();

            using var context = TestCorrelator.CreateContext();
            LogManager.Warning(randomString);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                Assert.True(item.Level == LogEventLevel.Warning);
                Assert.Equal(randomString, item.RenderMessage());
            });
        }

        [Fact]
        public void LogManager_WriteWarning_WithException()
        {
            var exception = new Exception("TestException");
            var randomString = Generator.RandomString();

            using var context = TestCorrelator.CreateContext();
            LogManager.Warning(exception, randomString);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = randomString;
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Warning);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteWarning_WithMultiplePropertyValues()
        {
            var now = DateTime.Now;
            var guid = Guid.NewGuid();
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Warning("[{Now:o}] {Guid} - Processed {@Coordinate} in {RandomInt:000} ms.", now, guid,
                coordinate, randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] {guid} - Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Warning);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteWarning_WithMultiplePropertyValuesWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;
            var guid = Guid.NewGuid();
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Warning(exception, "[{Now:o}] {Guid} - Processed {@Coordinate} in {RandomInt:000} ms.", now,
                guid, coordinate, randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] {guid} - Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Warning);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteWarning_WithThreePropertyValues()
        {
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Warning("[{Now:o}] Processed {@Coordinate} in {RandomInt:000} ms.", now, coordinate,
                randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Warning);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteWarning_WithThreePropertyValuesWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Warning(exception, "[{Now:o}] Processed {@Coordinate} in {RandomInt:000} ms.", now,
                coordinate, randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Warning);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteWarning_WithTwoPropertyValues()
        {
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };

            using var context = TestCorrelator.CreateContext();
            LogManager.Warning("[{Now:o}] Processed {@Coordinate}.", now, coordinate);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)}.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Warning);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteWarning_WithTwoPropertyValuesWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };

            using var context = TestCorrelator.CreateContext();
            LogManager.Warning(exception, "[{Now:o}] Processed {@Coordinate}.", now, coordinate);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)}.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Warning);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteWarning_WithOnePropertyValue()
        {
            var now = DateTime.Now;

            using var context = TestCorrelator.CreateContext();
            LogManager.Warning("[{Now:o}] Processed.", now);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Warning);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteWarning_WithOnePropertyValueWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;

            using var context = TestCorrelator.CreateContext();
            LogManager.Warning(exception, "[{Now:o}] Processed.", now);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Warning);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteError()
        {
            var randomString = Generator.RandomString();

            using var context = TestCorrelator.CreateContext();
            LogManager.Error(randomString);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                Assert.True(item.Level == LogEventLevel.Error);
                Assert.Equal(randomString, item.RenderMessage());
            });
        }

        [Fact]
        public void LogManager_WriteError_WithException()
        {
            var exception = new Exception("TestException");
            var randomString = Generator.RandomString();

            using var context = TestCorrelator.CreateContext();
            LogManager.Error(exception, randomString);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = randomString;
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Error);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteError_WithMultiplePropertyValues()
        {
            var now = DateTime.Now;
            var guid = Guid.NewGuid();
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Error("[{Now:o}] {Guid} - Processed {@Coordinate} in {RandomInt:000} ms.", now, guid,
                coordinate, randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] {guid} - Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Error);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteError_WithMultiplePropertyValuesWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;
            var guid = Guid.NewGuid();
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Error(exception, "[{Now:o}] {Guid} - Processed {@Coordinate} in {RandomInt:000} ms.", now,
                guid, coordinate, randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] {guid} - Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Error);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteError_WithThreePropertyValues()
        {
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Error("[{Now:o}] Processed {@Coordinate} in {RandomInt:000} ms.", now, coordinate,
                randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Error);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteError_WithThreePropertyValuesWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Error(exception, "[{Now:o}] Processed {@Coordinate} in {RandomInt:000} ms.", now, coordinate,
                randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Error);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteError_WithTwoPropertyValues()
        {
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };

            using var context = TestCorrelator.CreateContext();
            LogManager.Error("[{Now:o}] Processed {@Coordinate}.", now, coordinate);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)}.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Error);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteError_WithTwoPropertyValuesWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };

            using var context = TestCorrelator.CreateContext();
            LogManager.Error(exception, "[{Now:o}] Processed {@Coordinate}.", now, coordinate);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)}.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Error);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteError_WithOnePropertyValue()
        {
            var now = DateTime.Now;

            using var context = TestCorrelator.CreateContext();
            LogManager.Error("[{Now:o}] Processed.", now);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Error);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteError_WithOnePropertyValueWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;

            using var context = TestCorrelator.CreateContext();
            LogManager.Error(exception, "[{Now:o}] Processed.", now);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Error);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteFatal()
        {
            var randomString = Generator.RandomString();

            using var context = TestCorrelator.CreateContext();
            LogManager.Fatal(randomString);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                Assert.True(item.Level == LogEventLevel.Fatal);
                Assert.Equal(randomString, item.RenderMessage());
            });
        }

        [Fact]
        public void LogManager_WriteFatal_WithException()
        {
            var exception = new Exception("TestException");
            var randomString = Generator.RandomString();

            using var context = TestCorrelator.CreateContext();
            LogManager.Fatal(exception, randomString);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = randomString;
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Fatal);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteFatal_WithMultiplePropertyValues()
        {
            var now = DateTime.Now;
            var guid = Guid.NewGuid();
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Fatal("[{Now:o}] {Guid} - Processed {@Coordinate} in {RandomInt:000} ms.", now, guid,
                coordinate, randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] {guid} - Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Fatal);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteFatal_WithMultiplePropertyValuesWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;
            var guid = Guid.NewGuid();
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Fatal(exception, "[{Now:o}] {Guid} - Processed {@Coordinate} in {RandomInt:000} ms.", now,
                guid, coordinate, randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] {guid} - Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Fatal);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteFatal_WithThreePropertyValues()
        {
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Fatal("[{Now:o}] Processed {@Coordinate} in {RandomInt:000} ms.", now, coordinate,
                randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Fatal);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteFatal_WithThreePropertyValuesWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };
            var randomInt = Generator.RandomInt();

            using var context = TestCorrelator.CreateContext();
            LogManager.Fatal(exception, "[{Now:o}] Processed {@Coordinate} in {RandomInt:000} ms.", now, coordinate,
                randomInt);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage =
                    $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)} in {randomInt:000} ms.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Fatal);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteFatal_WithTwoPropertyValues()
        {
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };

            using var context = TestCorrelator.CreateContext();
            LogManager.Fatal("[{Now:o}] Processed {@Coordinate}.", now, coordinate);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)}.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Fatal);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteFatal_WithTwoPropertyValuesWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;
            var coordinate = new { Latitude = Generator.RandomInt(), Longitude = Generator.RandomInt() };

            using var context = TestCorrelator.CreateContext();
            LogManager.Fatal(exception, "[{Now:o}] Processed {@Coordinate}.", now, coordinate);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed {SerilogJson.Serialize(coordinate)}.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Fatal);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteFatal_WithOnePropertyValue()
        {
            var now = DateTime.Now;

            using var context = TestCorrelator.CreateContext();
            LogManager.Fatal("[{Now:o}] Processed.", now);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Fatal);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        [Fact]
        public void LogManager_WriteFatal_WithOnePropertyValueWithException()
        {
            var exception = new Exception("TestException");
            var now = DateTime.Now;

            using var context = TestCorrelator.CreateContext();
            LogManager.Fatal(exception, "[{Now:o}] Processed.", now);

            Assert.Collection(TestCorrelator.GetLogEventsFromCurrentContext(), item =>
            {
                var expectedMessage = $"[{now:o}] Processed.";
                var renderedMessage = item.RenderMessage();
                Assert.True(item.Level == LogEventLevel.Fatal);
                Assert.Equal(expectedMessage, renderedMessage);
            });
        }

        #endregion
    }
}
