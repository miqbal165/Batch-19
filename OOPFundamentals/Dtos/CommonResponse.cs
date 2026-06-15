namespace OOPFundamentals.Dtos;

public class CommonResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

    public static CommonResponse<T> Ok(T data, string message = "Success")
    {
        return new CommonResponse<T>
        {
            Success = true,
            Message = message,
            Data = data
        };
    }

    public static CommonResponse<T> Fail(string message)
    {
        return new CommonResponse<T>
        {
            Success = false,
            Message = message,
            Data = default
        };
    }
}