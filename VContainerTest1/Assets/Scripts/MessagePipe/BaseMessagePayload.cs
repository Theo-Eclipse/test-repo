namespace Wolfdev.MessagePipe
{
    public class BaseMessagePayload<T>
    {
        public T Data;
        public object Source;

        public BaseMessagePayload(T data, object source = null)
        {
            Data = data;
            Source = source;
        }
    }
}