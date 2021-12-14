namespace Utils.Response;

public class SingleResponse<T> : BaseResponse, IResponse
{
    public SingleResponse() : base()
    {
    }

    public SingleResponse(IResponse response) : this(response.HasSuccess, response.Message)
    {
    }

    public SingleResponse(bool hasSuccess, string message) : base(hasSuccess, message)
    {
    }

    public SingleResponse(Exception ex) : base(ex) { }

    public T Item { get; set; }
}
