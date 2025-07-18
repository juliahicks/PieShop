using PieShopHRM.Shared.Domain;

namespace PieShop.Contracts.Services
{
    public interface IEmployeeDataService
    {

        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeDetails(int employeeId);
    }
}
