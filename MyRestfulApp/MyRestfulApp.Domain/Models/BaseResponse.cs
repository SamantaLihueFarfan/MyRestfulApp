namespace MyRestfulApp.Domain.Models
{
    public class BaseResponse
    {
        public string? Message { get; set; }
        public IList<string>? Errors { get; set; } = new List<string>();

        public bool IsValid
        {
            get => Errors is null || !Errors.Any();
        }
    }
}

