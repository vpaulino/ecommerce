﻿using Microsoft.AspNetCore.Components;
using WebSite.Models;
using WebSite.Services;

namespace WebSite.Pages
{
    public partial class Index
    {
        private IEnumerable<Product> displayedProducts = new List<Product>();
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalPages;
        private string searchText = "";

        [Inject]
        private ProductsService ProductsService { get; set; }


        [Parameter]
        public bool ProductsLoading { get; set; }

        [Parameter]
        public string ErrorMessage { get; set; }

        [Parameter]
        public long LastProductId { get; set; }

        public Index()
        {

        }

        protected override async Task OnInitializedAsync()
        {
            
            base.OnInitialized();
            await FetchProductsAsync();
        }


        private async Task FetchProductsAsync()
        {
            
            await ManageTableState(async ()=> await ProductsService.GetAllProducts(LastProductId, pageSize, CancellationToken.None));
          
        }

        private async Task PreviousOnClick() 
        {
           
            await ManageTableState(async () => await ProductsService.GetAllProducts(LastProductId - 2*pageSize, pageSize, CancellationToken.None));
            this.currentPage--;
        }

        private async Task NextOnClick()
        {
            this.currentPage++;
            await ManageTableState(async () => await ProductsService.GetAllProducts(LastProductId, pageSize, CancellationToken.None));

        }

        private async Task Search()
        {
            
            await ManageTableState(async () => await ProductsService.GetAllProductsByKeyword(LastProductId, pageSize, searchText, CancellationToken.None));
        }
 

        private async Task ManageTableState(Func<Task<IEnumerable<Product>>> productServiceHandler)
        {
            try
            {
                this.ErrorMessage = string.Empty;
                ProductsLoading = true;

                long totalRecordsCount = await this.ProductsService.GetProductsCount(CancellationToken.None);

                this.totalPages = ((int)(totalRecordsCount / this.pageSize))+1;


                var products = await productServiceHandler();
                if (products.Any())
                {
                    this.LastProductId = products.Max(product => product.Id)+1;
                    this.displayedProducts = products;
                    
                }
                else 
                {
                    this.ErrorMessage = "No products found";
                }
                
                
            }
            catch (Exception ex)
            {
                this.ErrorMessage = "There was a problem fetching the products, If the problem persists please contact Support";

             
            }finally 
            { 
                ProductsLoading = false;
           

            }

        }
    }
}
