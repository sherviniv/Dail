namespace Dail.Application.Common.Models.DataTransferObjects;
public class ServerResult<T>
{
    public T Data { get; set; }

    public ServerResult(T data)
    {
        Data = data;
    }
}
