namespace HTDA.Framework.Core.Primitives
{
    /// <summary>
    /// Result with value. Value is only valid when IsOk == true.
    /// </summary>
    public readonly struct Result<T>
    {
        public bool IsOk { get; }
        public string Error { get; }
        public T Value { get; }

        private Result(bool isOk, T value, string error)
        {
            IsOk = isOk;
            Value = value;
            Error = error;
        }

        public static Result<T> Ok(T value) => new Result<T>(true, value, null);
        public static Result<T> Fail(string error) => new Result<T>(false, default, error ?? "Unknown error");

        public override string ToString()
            => IsOk ? "Ok" : $"Fail: {Error}";
    }
}