namespace Core.Exceptions;
[Serializable]
public class NotFoundException : Exception
{
    public new string Message { get; set; }= string.Empty;

    public NotFoundException()
    {
        Message = "We coudn't find that";
    }

    public NotFoundException(string message) : base(message)
    {
        Message = message;
    }

    public NotFoundException(string message, Exception inner) : base(message, inner)
    {
        Message = message;
    }

    protected NotFoundException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
        :base(serializationInfo, streamingContext) { }

}