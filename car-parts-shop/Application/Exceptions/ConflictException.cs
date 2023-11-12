using System.Net;

namespace Application.Exceptions;

public class ConflictException : ExceptionBase
{
    private static string DefaultMessageHeader => "Conflict";
    public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public ConflictException(string message, string messageHeader = null!)
        : base(message, messageHeader ?? DefaultMessageHeader) { }
}
