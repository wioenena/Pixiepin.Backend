namespace Pixiepin.Backend.Shared.Result;

public sealed class Result<TValue, TError> {
    public TValue? Value { get; set; }
    public TError? Error { get; set; }

    internal Result(TValue value) {
        this.Value = value;
    }

    internal Result(TError error) {
        this.Error = error;
    }
}

public static class Result {
    public static Result<TValue, TError> Ok<TValue, TError>(TValue value) => new(value);

    public static Result<TValue, TError> Err<TValue, TError>(TError error) => new(error);
}
