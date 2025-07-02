using PieShop.Services;
using PieShopHRM.Shared.Domain;

namespace PieShop.Components.Pages
{
    public partial class EmployeeOverview
    {
        public List<Employee> Employees { get; set; } = default!;

        protected async override Task OnInitializedAsync()
        {
            Employees = MockDataService.Employees;
        }
    }
}
