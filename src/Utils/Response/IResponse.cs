namespace Utils.Response;

public interface IResponse
{
    public string Message { get; set; }
    public bool HasSuccess { get; set; }
    public Exception Exception { get; set; }
    public IEnumerable<string> Errors { get; }

    public BaseResponse AddError(string message);
}
