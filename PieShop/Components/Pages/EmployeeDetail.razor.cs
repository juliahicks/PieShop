using Microsoft.AspNetCore.Components;
using PieShop.Services;
using PieShopHRM.Shared.Domain;
using PieShop.Contracts.Services;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace PieShop.Components.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();

        public List<TimeRegistration> TimeRegistrations { get; set; } = [];

        [Inject]
        public IEmployeeDataService? EmployeeDataService { get; set; }

        [Inject]
        public ITimeRegistrationDataService? TimeRegistrationDataService { get; set; }
        private float itemHeight = 50;

        protected async override Task OnInitializedAsync()
        {
            //Employee = MockDataService.Employees.Single(e => e.EmployeeId == EmployeeId);
            Employee = await EmployeeDataService.GetEmployeeDetails(EmployeeId);
            TimeRegistrations = await TimeRegistrationDataService.GetTimeRegistrationsForEmployee(EmployeeId);
        }

        public async ValueTask<ItemsProviderResult<TimeRegistration>>
            LoadTimeRegistrations(ItemsProviderRequest request)
        {
            int totalNumberOfTimeRegistrations =
                await TimeRegistrationDataService.GetTimeRegistrationCountForEmployeeId(EmployeeId);

            var numberOfTimeRegistrations = Math.Min(request.Count, totalNumberOfTimeRegistrations - request.StartIndex);
            var listItems = await TimeRegistrationDataService.GetPagedTimeRegistrationsForEmployee(
                EmployeeId, numberOfTimeRegistrations, request.StartIndex);

            return new ItemsProviderResult<TimeRegistration>(listItems, totalNumberOfTimeRegistrations);
        }

        private void ChangeHolidayState()
        {
            Employee.IsOnHoliday = !Employee.IsOnHoliday;
        }
    }

}
