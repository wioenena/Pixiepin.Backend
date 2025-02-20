using Pixiepin.Backend.Application.Exceptions.Common;

namespace Pixiepin.Backend.Application.Exceptions;

public sealed class ValidationException(string message, IEnumerable<ValidationException>? errors) : BaseException(message, ExceptionType.Validation, errors);
