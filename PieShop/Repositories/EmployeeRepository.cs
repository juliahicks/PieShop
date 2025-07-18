using Microsoft.EntityFrameworkCore;
using PieShop.Contracts.Repositories;
using PieShop.Data;
using PieShopHRM.Shared.Domain;

namespace PieShop.Repositories
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {

        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(IDbContextFactory<AppDbContext> DbFactory)
        {
            _appDbContext = DbFactory.CreateDbContext();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            return await _appDbContext.Employees.FirstOrDefaultAsync(c => c.EmployeeId == employeeId);
        }
    }
}
