namespace HTDA.Framework.Core.Primitives
{
    /// <summary>
    /// Lightweight success/failure result without throwing exceptions.
    /// </summary>
    public readonly struct Result
    {
        public bool IsOk { get; }
        public string Error { get; }

        private Result(bool isOk, string error)
        {
            IsOk = isOk;
            Error = error;
        }

        public static Result Ok() => new Result(true, null);
        public static Result Fail(string error) => new Result(false, error ?? "Unknown error");

        public override string ToString()
            => IsOk ? "Ok" : $"Fail: {Error}";
    }
}