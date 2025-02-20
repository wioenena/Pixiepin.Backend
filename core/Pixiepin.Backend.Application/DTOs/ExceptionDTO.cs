using Pixiepin.Backend.Application.Exceptions.Common;

namespace Pixiepin.Backend.Application.DTOs;

public sealed record ExceptionDTO(string title, ExceptionType type, string message, IEnumerable<ExceptionDTO>? errors);
