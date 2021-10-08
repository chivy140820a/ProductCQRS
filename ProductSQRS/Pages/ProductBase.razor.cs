using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using ProductSQRS.API.Constant;
using ProductSQRS.API.Entity;
using ProductSQRS.API.EventVm;
using ProductSQRS.API.EventVMRequest;
using ProductSQRS.ConnectAPI.CheckConnectAPI;
using ProductSQRS.ConnectAPI.ProductCnAPI;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ProductSQRS.API.EventRequest.Event;

namespace ProductSQRS.Pages
{
    public partial class ProductBase
    {
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public ICheckConnectAPI checkConnectAPI { get; set; }
        [Inject]
        public AuthenticationStateProvider GetAuthenticationStateAsync { get; set; }
        [Inject]
        public IProductConnectAPI productConnectAPI { get; set; }
        public List<Product> list { get; set; } = new List<Product>();

        public async Task CreateRecive()
        {
            var authstate = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
            var user = authstate.User;
            var name = user.Identity.Name;
            var check = await checkConnectAPI.Check(name);
            if(check==true)
            {
                var create = new CreateRecive()
                {
                    ProductId = 2,
                    Quantity = 10,
                    Common = Common.Recived
                };
                await productConnectAPI.AddRecive(create);

            }
            else
            {
                navigationManager.NavigateTo("/Ann");
            }
          
           
        }
        public async Task CreateSend()
        {
            var authstate = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
            var user = authstate.User;
            var name = user.Identity.Name;
            var check = await checkConnectAPI.Check(name);
            if(check == true)
            {
                var create = new CreateSend()
                {
                    ProductId = 2,
                    Quantity = 10,
                    Common = Common.Sended
                };
                await productConnectAPI.AddSend(create);
            }
            else
            {
                navigationManager.NavigateTo("/Ann");
            }
        }
        public async Task CreateAdjusted()
        {
            var authstate = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
            var user = authstate.User;
            var name = user.Identity.Name;
            var check = await checkConnectAPI.Check(name);
            if(check==true)
            {
                var create = new CreateAdjused()
                {
                    ProductId = 2,
                    Quantity = 10,
                    Common = Common.Ajuseded
                };
                await productConnectAPI.AddAdjusted(create);
            }
            else
            {
                navigationManager.NavigateTo("/Ann");
            }
        }
        protected override async Task OnInitializedAsync()
        {
            list = await productConnectAPI.GetAllProduct();
        }
        
    }
}
