namespace CarParking.Api.Wrappers
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
        }            

        public ApiResponse(T data)
        {
            Succeeded = true;
            Data = data;
            Errors = null;
            Message = string.Empty;
        }

        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
}
