using Pixiepin.Backend.Application.Exceptions.Common;

namespace Pixiepin.Backend.Application.Exceptions;

public sealed class EntityAlreadyExistException(string message) : BaseException(message, ExceptionType.EntityAlreadyExist, null);
