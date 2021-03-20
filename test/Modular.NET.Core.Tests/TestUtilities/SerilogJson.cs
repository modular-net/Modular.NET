using Newtonsoft.Json;

namespace Modular.NET.Core.Tests.TestUtilities
{
    public static class SerilogJson
    {
        #region Static Methods

        public static string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value)
                .Replace("\"", "")
                .Replace("{", "{ ")
                .Replace("}", " }")
                .Replace(":", ": ")
                .Replace(",", ", ");
        }

        #endregion
    }
}
