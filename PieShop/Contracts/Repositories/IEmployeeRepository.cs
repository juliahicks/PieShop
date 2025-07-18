using PieShopHRM.Shared.Domain;

namespace PieShop.Contracts.Repositories
{
    public interface IEmployeeRepository
    {

        Task<IEnumerable<Employee>> GetAllEmployees();

        Task<Employee> GetEmployeeById(int employeeId);
    }
}
