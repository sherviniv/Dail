using System.Net;

namespace Dail.Application.Common.Exceptions;

public class DailException : Exception
{
    public string Code { get; }
    public HttpStatusCode StatusCode { get; set; }
    public DailException()
    {
    }

    public DailException(string code)
    {
        Code = code;
    }

    public DailException(string message, HttpStatusCode httpStatusCode, params object[] args) : this(string.Empty, message, httpStatusCode, args)
    {
    }

    public DailException(string code, string message, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest, params object[] args) : this(null!, code, message, args)
    {
        StatusCode = httpStatusCode;
    }

    public DailException(Exception innerException, string message, params object[] args)
        : this(innerException, string.Empty, message, args)
    {
    }

    public DailException(Exception innerException, string code, string message, params object[] args)
        : base(string.Format(message, args), innerException)
    {
        Code = code;
    }
}