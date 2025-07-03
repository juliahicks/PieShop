﻿using Microsoft.AspNetCore.Components;
using PieShop.Services;
using PieShopHRM.Shared.Domain;

namespace PieShop.Components.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();

        protected override void OnInitialized()
        {
            Employee = MockDataService.Employees.Single(e => e.EmployeeId == EmployeeId);
        }

        private void ChangeHolidayState()
        {
            Employee.IsOnHoliday = !Employee.IsOnHoliday;
        }
    }

}
