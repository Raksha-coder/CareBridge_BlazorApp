namespace App.Application.DTOs
{
    public class JsonResponseDto
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public JsonResponseDto(int status, string message, object data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }
}
