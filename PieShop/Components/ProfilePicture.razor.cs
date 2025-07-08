using Microsoft.AspNetCore.Components;

namespace PieShop.Components
{
    public partial class ProfilePicture
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
