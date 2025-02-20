using Pixiepin.Backend.Application.Exceptions.Common;

namespace Pixiepin.Backend.Application.Exceptions;

public sealed class InvalidPasswordException(string message) : BaseException(message, ExceptionType.InvalidPassword, null);
