using System.Net;

namespace CashRegister.Api.Models.Dfs;

public class ApiException : Exception
{
    protected ApiException(HttpStatusCode statusCode, string message)
        : base(message)
    {
        StatusCode = statusCode;
    }

    public HttpStatusCode StatusCode { get; }
}

public class BusinessLogicException : ApiException
{
    public BusinessLogicException(string message)
        : base(HttpStatusCode.BadRequest, message)
    {
    }
}

public class NotFoundException : ApiException
{
    public NotFoundException(string message)
        : base(HttpStatusCode.NotFound, message)
    {
    }
}

public class ConflictException : ApiException
{
    public ConflictException(string message)
        : base(HttpStatusCode.Conflict, message)
    {
    }
}

public class DfsException : ApiException
{
    public DfsException(string message)
        : base(HttpStatusCode.BadRequest, message)
    {
    }
}