namespace HTDA.Framework.Core
{
    /// <summary>
    /// Core package identity (useful for diagnostics and cross-module compatibility checks).
    /// Keep this stable.
    /// </summary>
    public static class CoreInfo
    {
        public const string Name = "HTDA.Framework.Core";

        // Keep in sync with package.json when you bump versions.
        public const string Version = "0.1.0";
    }
}