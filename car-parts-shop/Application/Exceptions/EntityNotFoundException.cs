using System.Net;

namespace Application.Exceptions;

public class EntityNotFoundException : ExceptionBase
{
    private static string DefaultMessageHeader => "Not Found";
    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

    public EntityNotFoundException(string message, string messageHeader = null!)
        : base(message, messageHeader ?? DefaultMessageHeader) { }
}
