namespace CarParking.Api.Wrappers
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            Succeeded = true;
            Data = null;
            Errors = null;
            Message = string.Empty;
        }            

        public ApiResponse(object data)
        {
            Succeeded = true;
            Data = data;
            Errors = null;
            Message = string.Empty;
        }

        public object Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
}
