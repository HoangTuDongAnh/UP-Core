using System;
using UnityEngine;

namespace HTDA.Framework.Core.Diagnostics
{
    /// <summary>
    /// Default log sink that writes to Unity console.
    /// </summary>
    public sealed class UnityLogSink : ILogSink
    {
        public void Info(string message) => Debug.Log(message);
        public void Warn(string message) => Debug.LogWarning(message);
        public void Error(string message) => Debug.LogError(message);

        public void Exception(Exception ex, string message = null)
        {
            if (!string.IsNullOrEmpty(message))
                Debug.LogError(message);

            Debug.LogException(ex);
        }
    }
}