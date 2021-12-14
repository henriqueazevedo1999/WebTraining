namespace Utils.Response;

public class Response : BaseResponse
{
    public Response() : base()
    {
    }

    public Response(bool hasSuccess, string message) : base(hasSuccess, message)
    {
    }

    public Response(Exception ex) : base(ex)
    {
    }
}
