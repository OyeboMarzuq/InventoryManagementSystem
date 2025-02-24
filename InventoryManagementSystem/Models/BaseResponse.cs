using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InventoryManagementSystem.Models
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        public bool IsSuccessful { get; internal set; }
        public bool Status { get; internal set; }

        public BaseResponse()
        {
            Success = false;
            Errors = new List<string>();
        }

        public BaseResponse(bool success, string message, T data = default!)
        {
            Success = success;
            Message = message;
            Data = data;
            Errors = new List<string>();
        }
    }
}
