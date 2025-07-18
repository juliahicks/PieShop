using PieShop.State;
using Microsoft.AspNetCore.Components;

namespace PieShop.Components
{
    public partial class InboxCounter
    {
        [Inject]
        public ApplicationState ApplicationState { get; set; }

        private int MessageCount;

        protected override void OnInitialized()
        {
            // Simulate fetching the message count from a service or state
            MessageCount = new Random().Next(10);

            ApplicationState.NumberOfMessages = MessageCount;
        }
    }
}
