using System.Net;

namespace Application.Exceptions;

public class UnauthorizedException : ExceptionBase
{
    private static string DefaultMessageHeader => "Unauthorized";
    public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

    public UnauthorizedException(string message, string messageHeader = null!)
        : base(message, messageHeader ?? DefaultMessageHeader) { }
}
