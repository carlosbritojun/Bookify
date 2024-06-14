using System.Diagnostics.CodeAnalysis;

namespace Bookify.Domain.Abstractions;

public class Result
{
    protected internal Result(bool isSucess, Error error)
    {
        if (isSucess && error != Error.None)
        {
            throw new InvalidOperationException();
        }

        if (!isSucess && error == Error.None)
        {
            throw new InvalidOperationException();
        }

        IsSucess = isSucess;
        Error = error;
    }

    public bool IsSucess { get; }
    public bool IsFailure => !IsSucess;
    public Error Error { get; }
    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);
    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
    public static Result<TValue> Create<TValue>(TValue? value) => 
        value is not null 
            ? Success(value) 
            : Failure<TValue>(Error.NullValue);
}

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(TValue? value, bool isSucess, Error error)
        : base(isSucess, error)
    {
        _value = value;
    }

    [NotNull]
    public TValue Value => IsSucess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");

    public static implicit operator Result<TValue>(TValue? value) => Create(value);
}
