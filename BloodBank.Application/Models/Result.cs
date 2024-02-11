namespace BloodBank.Application.Models
{
    public class Result<T>
    {
        public T Data { get; private set; }
        public bool HasError { get; private set; }
        public string ErrorMessage { get; private set; }

        public Result(T data, string errorMessage, bool hasError = false)
        {
            Data = data;
            HasError = hasError;
            ErrorMessage = errorMessage;
        }

        public Result(bool hasError, string errorMessage)
        {
            HasError = hasError;
            ErrorMessage = errorMessage;
        }
    }
}
