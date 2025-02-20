using Pixiepin.Backend.Application.Exceptions.Common;

namespace Pixiepin.Backend.Application.Exceptions;

public sealed class InternalServerException(string message) : BaseException(message, ExceptionType.InternalServerError, null);
