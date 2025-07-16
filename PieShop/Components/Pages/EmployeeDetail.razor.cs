using Microsoft.AspNetCore.Components;
using PieShop.Services;
using PieShopHRM.Shared.Domain;
using PieShop.Contracts.Services;

namespace PieShop.Components.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //Employee = MockDataService.Employees.Single(e => e.EmployeeId == EmployeeId);
            Employee = await EmployeeDataService.GetEmployeeDetails(EmployeeId);
        }

        private void ChangeHolidayState()
        {
            Employee.IsOnHoliday = !Employee.IsOnHoliday;
        }
    }

}
