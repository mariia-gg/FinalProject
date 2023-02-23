namespace Application.Common.Exceptions;

public class ForbiddenAccessException : Exception
{
    public ForbiddenAccessException(string name, object key) : base($"Entity \"{name}\" ({key}) not found.")
    {
    }
}
