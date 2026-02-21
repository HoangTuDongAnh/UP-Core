using System;

namespace HTDA.Framework.Core.Diagnostics
{
    /// <summary>
    /// Minimal logging facade for the whole framework.
    /// Modules should call HTDALog instead of Debug.Log directly.
    /// </summary>
    public static class HTDALog
    {
        private static ILogSink _sink;

        /// <summary>
        /// Current log sink. Defaults to UnityLogSink when first accessed.
        /// </summary>
        public static ILogSink Sink
        {
            get => _sink ??= new UnityLogSink();
            set => _sink = value;
        }

        public static void Info(string message) => Sink.Info(Format(message));
        public static void Warn(string message) => Sink.Warn(Format(message));
        public static void Error(string message) => Sink.Error(Format(message));
        public static void Exception(Exception ex, string message = null) => Sink.Exception(ex, Format(message));

        private static string Format(string message)
        {
            if (string.IsNullOrEmpty(message))
                return "[HTDA]";

            return $"[HTDA] {message}";
        }
    }
}