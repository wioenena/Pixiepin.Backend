using Pixiepin.Backend.Application.DTOs;
using Pixiepin.Backend.Application.Interfaces;

namespace Pixiepin.Backend.Application.Exceptions.Common;

public abstract class BaseException(string message, ExceptionType type, IEnumerable<BaseException>? errors) : Exception(message), IToJSON<ExceptionDTO> {
    public ExceptionType Type { get; } = type;
    public IEnumerable<BaseException>? Errors { get; } = errors;


    public ExceptionDTO ToJSON() => new(
        this.GetType().Name,
        this.Type,
        this.Message,
        this.Errors?.Select(e => e.ToJSON())
    );
}
