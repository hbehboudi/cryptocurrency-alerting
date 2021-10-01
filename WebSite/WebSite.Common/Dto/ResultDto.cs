namespace WebSite.Common.Dto
{
    public class ResultDto
    {
        public bool IsSuccess { get; }

        public string Message { get; }

        public ResultDto(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }

    public class ResultDto<T>
    {
        public bool IsSuccess { get; }

        public string Message { get; }

        public T Data { get; }

        public ResultDto(bool isSuccess, string message, T data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }
    }
}
