using Framework.Core.ExceptionHandling;

namespace gRPCExceptionHandling.Domain.Users.Exceptions;

public class NationalCodeIsInvalidException : DomainException
{
    public NationalCodeIsInvalidException() : base("NationalCode is not valid.")
    {
    }
}