namespace Framework.Core.ExceptionHandling;

public abstract class DomainException(string message) : Exception(message)
{
}