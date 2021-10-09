using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProductSQRS.API.Constant;
using ProductSQRS.API.Entity;
using ProductSQRS.API.EventVm;
using ProductSQRS.API.EventVMRequest;
using ProductSQRS.ConnectAPI.CheckConnectAPI;
using ProductSQRS.ConnectAPI.ProductCnAPI;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static ProductSQRS.API.EventRequest.Event;

namespace ProductSQRS.Pages
{
    public partial class ProductBase
    {
        [Inject]
        public IWebHostEnvironment env { get; set; }

        public IReadOnlyList<IBrowserFile> selectedFiles { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public ICheckConnectAPI checkConnectAPI { get; set; }
        [Inject]
        public AuthenticationStateProvider GetAuthenticationStateAsync { get; set; }
        [Inject]
        public IProductConnectAPI productConnectAPI { get; set; }
        public List<Product> list { get; set; } = new List<Product>();
        public Dictionary<int, IList<IEvent>> listEventById { get; set; } = new Dictionary<int, IList<IEvent>>();
        public string PathImage { get; set; }
        public Product product { get; set; } = new Product();
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
        public void OnSubmit()
        {

        }
        public async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFiles = e.GetMultipleFiles();

            foreach (var file in selectedFiles)
            {
                Stream stream = file.OpenReadStream();
                var path = $"{env.WebRootPath}\\{file.Name}";
                FileStream fs = File.Create(path);
                await stream.CopyToAsync(fs);
                stream.Close();
                fs.Close();
                PathImage = path;
            }
        }

    }
}
