using BlazorApp.Data;
using eshop.CoreBussiness.Service;
using eShop.DataStore.HardCoded;
using eShop.ShoppingCart.LocalStorage;
using eShop.UseCases.AdminPortal.OrderDetailScreen;
using eShop.UseCases.AdminPortal.OutstandingOrder;
using eShop.UseCases.AdminPortal.ProcessedOrder;
using eShop.UseCases.PluginInterface.DataStore;
using eShop.UseCases.PluginInterface.StateStore;
using eShop.UseCases.PluginInterface.StateStore.Implmentaion;
using eShop.UseCases.SearchProductScreen;
using eShop.UseCases.ShoppingCartScreen;
using eShop.UseCases.UI;
using eShop.UseCases.ViewProductScreen;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //for adding Auth
            services.AddControllers();
            services.AddAuthentication(CookieCommon.CookieNameStatic)
                .AddCookie(CookieCommon.CookieNameStatic,config=> {
                    config.Cookie.Name = CookieCommon.CookieNameStatic;
                    config.LoginPath = "/authenticate";
                    
                });

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            //adding for Order processed
            services.AddSingleton<IOrderRespository, OrderRepository>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ISearchProduct, SearchProduct>();
            services.AddTransient<IViewProduct, ViewProduct>();
            services.AddScoped<IShoppingCart, ShoppingCart>();
            // for adding the shopping cart state 
            services.AddScoped<IShoppingCartSateStore, ShoppingCartStateStore>();
            services.AddTransient<IAddProductToUseCase, AddProductToUseCase>();
            services.AddTransient<IShoppingCartUseCase, ShoppingCartUseCase>();
            services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
            services.AddTransient<IUpdateQuantityUseCase, UpdateQuantityUseCase>();
            //for adding the place order
            services.AddTransient<IPlaceOrderUseCase, PlaceOrderUseCase>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IViewOrderConfirmationUseCase, ViewOrderConfirmationUseCase>();

            //for Admin Portal
            services.AddTransient<IViewOrderDetailsUseCase, ViewOrderDetailsUseCase>();
            services.AddTransient<IViewOutStadingOrderUseCase, ViewOutStadingOrderUseCase>();
            services.AddTransient<IProcessedOrderUseCase, ProcessedOrderUseCase>();
            services.AddTransient<IViewProcessedOrderUseCase, ViewProcessedOrderUseCase>();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //for Author
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //for Author
                endpoints.MapControllers();

                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
