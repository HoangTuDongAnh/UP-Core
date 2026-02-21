using System;

namespace HTDA.Framework.Core.Validation
{
    public static class Guard
    {
        public static T NotNull<T>(T value, string paramName) where T : class
        {
            if (value == null)
                throw new ArgumentNullException(paramName);
            return value;
        }

        public static string NotNullOrEmpty(string value, string paramName)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Value cannot be null or empty.", paramName);
            return value;
        }

        public static int InRange(int value, int minInclusive, int maxInclusive, string paramName)
        {
            if (value < minInclusive || value > maxInclusive)
                throw new ArgumentOutOfRangeException(paramName, value, $"Expected {minInclusive}..{maxInclusive}");
            return value;
        }
    }
}