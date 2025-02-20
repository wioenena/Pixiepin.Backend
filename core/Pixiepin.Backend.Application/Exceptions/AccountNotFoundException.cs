using Pixiepin.Backend.Application.Exceptions.Common;

namespace Pixiepin.Backend.Application.Exceptions;

public sealed class AccountNotFoundException(string message) : BaseException(message, ExceptionType.AccountNotFound, null);
