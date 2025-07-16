using PieShop.Contracts.Services;
using PieShop.Services;
using PieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace PieShop.Components.Pages
{
    public partial class EmployeeOverview
    {
        public List<Employee> Employees { get; set; } = default!;
        private Employee? _selectedEmployee;

        private string Title => "Employee Overview";

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //await Task.Delay(2000); // Simulate async data loading
            //Employees = MockDataService.Employees;
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
        }

        public void ShowQuickViewPopup(Employee selectedEmployee)
        {
            _selectedEmployee = selectedEmployee;
        }
    }
}
