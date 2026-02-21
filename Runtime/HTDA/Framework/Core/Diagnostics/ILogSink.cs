using System;

namespace HTDA.Framework.Core.Diagnostics
{
    public interface ILogSink
    {
        void Info(string message);
        void Warn(string message);
        void Error(string message);
        void Exception(Exception ex, string message = null);
    }
}