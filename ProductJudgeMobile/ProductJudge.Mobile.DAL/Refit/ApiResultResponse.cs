namespace ProductJudge.Mobile.DAL.Refit;

public class ApiResultResponse<T> : ApiResultResponse where T : class
{
    public readonly T? Value;

    protected ApiResultResponse(T value)
        : base()
    {
        Value = value;
    }

    protected ApiResultResponse(string errorMessage)
        : base(errorMessage)
    {
    }

    public static ApiResultResponse<T> CreateSuccess(T value)
    {
        return new ApiResultResponse<T>(value);
    }

    public new static ApiResultResponse<T> CreateError(string errorMessage = "")
    {
        return new ApiResultResponse<T>(errorMessage);
    }
}

public class ApiResultResponse
{
    private readonly bool _isSuccess;

    public bool IsSuccess => _isSuccess;

    public bool IsError => !_isSuccess;

    public string ErrorMessage { get; protected set; } = string.Empty;

    protected ApiResultResponse()
    {
        _isSuccess = true;
    }

    protected ApiResultResponse(string errorMessage)
    {
        ErrorMessage = errorMessage;
        _isSuccess = false;
    }

    public static ApiResultResponse CreateSuccess()
    {
        return new ApiResultResponse();
    }

    public static ApiResultResponse CreateError(string errorMessage = "")
    {
        return new ApiResultResponse(errorMessage);
    }
}
