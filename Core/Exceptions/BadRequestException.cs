namespace Core.Exceptions;

[Serializable]
public class BadRequestException : Exception
{
    public new string Message { get; set; } = string.Empty;

    public BadRequestException()
    {
        Message = "Illegal request";
    }

    public BadRequestException(string message) : base(message)
    {
        Message = message;
    }

    public BadRequestException(string message, Exception inner) : base(message, inner)
    {
        Message = message;
    }

    protected BadRequestException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
         : base(serializationInfo, streamingContext) { }
}