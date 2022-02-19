namespace ColumbusTest.Models
{
    public class ApiResponse<T>
    {
        public T Result { get; set; }
        public string ErrorMsg { get; set; }
        public bool IsSuccess => string.IsNullOrEmpty(ErrorMsg);    
    }
}
