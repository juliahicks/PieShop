using PieShopHRM.Shared.Domain;

namespace PieShop.Contracts.Services
{
    public interface ITimeRegistrationDataService
    {
        Task<List<TimeRegistration>> GetPagedTimeRegistrationsForEmployee(int employeeId, int pageSize, int start);
        Task<int> GetTimeRegistrationCountForEmployeeId(int employeeId);
        Task<List<TimeRegistration>> GetTimeRegistrationsForEmployee(int employeeId);
    }
}
