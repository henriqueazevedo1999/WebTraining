namespace Utils.Response;

public class DataResponse<T> : BaseResponse
{
    public DataResponse() : base() { }
    public DataResponse(bool hasSuccess, string message) : base(hasSuccess, message) { }
    public DataResponse(Exception ex) : base(ex) { }

    public List<T> Data { get; set; }
}
