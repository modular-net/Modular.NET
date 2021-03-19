// ReSharper disable once CheckNamespace

public static class StringHelper
{
    #region Static Methods

    public static string GenerateRandomString(int length,
        bool numeric = false,
        bool lowercase = false,
        bool uppercase = false,
        string additionalCharacters = null)
    {
        return "".GenerateRandomString(length, numeric, lowercase, uppercase, additionalCharacters);
    }

    #endregion
}
