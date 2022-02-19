using ColumbusTest.Models;
using Microsoft.AspNetCore.WebUtilities;

namespace ColumbusTest.Services
{
    public class ColumbusService : HttpService<ColumbusService>, IColumbusService
    {
        private readonly IConfiguration _configuration;
        private readonly string _employeesEndpoint;

        public ColumbusService(HttpClient httpClient, ILogger<ColumbusService> logger, IConfiguration configuration) : base(httpClient, logger)
        {
            _configuration = configuration;
            _employeesEndpoint = _configuration["EmployeesEndpoint"];
        }

        public async Task<ApiResponse<List<Employee>>> GetEmployees(int? skip, int? take)
        {
            var queryString = new Dictionary<string, string>() { };

            if (skip.HasValue)
            {
                queryString.Add("skip", skip.ToString());
            }

            if (take.HasValue)
            {
                queryString.Add("take", take.ToString());
            }

            var endpoint = new Uri(QueryHelpers.AddQueryString(_employeesEndpoint, queryString));
            var response = await HttpGet<List<Employee>>(endpoint.AbsoluteUri);
            return response;
        }

        public async Task<ApiResponse<EmployeeDetails>> GetEmployee(int id)
        {
            var endpoint = $"{_employeesEndpoint}/{id}";
            var response = await HttpGet<EmployeeDetails>(endpoint);
            return response;
        }
    }
}
