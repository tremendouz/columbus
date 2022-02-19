namespace ColumbusTest.Models
{
    public class EmployeeDetails
    {
        public DateTime DayOfEmployment { get; set; }
        public string PhoneNumber { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public List<Link> Links { get; set; }
    }
}
