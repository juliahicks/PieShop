﻿using Microsoft.AspNetCore.Components;
using PieShopHRM.Shared.Domain;

namespace PieShop.Components
{
    public partial class EmployeeCard
    {
        [Parameter]
        public Employee Employee { get; set; } = default!;

        [Parameter]
        public EventCallback<Employee> EmployeeQuickViewClicked { get; set; }

        protected override void OnInitialized()
        {
            if (string.IsNullOrEmpty(Employee.LastName))
            {
                throw new Exception("Employee LastName cannot be null or empty.");
            }
        }
    }
}
