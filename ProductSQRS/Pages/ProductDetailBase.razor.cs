using Microsoft.AspNetCore.Components;
using ProductSQRS.ConnectAPI.ProductCnAPI;
using System.Threading.Tasks;
using System.Collections.Generic;
using static ProductSQRS.API.EventRequest.Event;
using ProductSQRS.API.EventVMRequest;

namespace ProductSQRS.Pages
{
    public partial class ProductDetailBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public IProductConnectAPI productConnectAPI { get; set; }
        public List<EventViewModel> ListEventById { get; set; } = new List<EventViewModel>();
        protected override async Task OnInitializedAsync()
        {
            ListEventById = await productConnectAPI.GetAllById(Id);
        }
    }
}
