using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMVC.Data;
using SalesWebMVC.Services;
using System.Globalization;

namespace SalesWebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<SalesWebMVCContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SalesWebMVCContext") ?? throw new InvalidOperationException("Connection string 'SalesWebMVCContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<SeedingService>(); //adiciono o seedingservice ao escopo do builder
            builder.Services.AddScoped<SellerService>();
            builder.Services.AddScoped<DepartmentService>();
            builder.Services.AddScoped<SalesRecordService>();
            

            var app = builder.Build();
            var ptBR = new CultureInfo("pt-BR"); //crio o CultureInfo pro idioma desejado
            var localizations = new RequestLocalizationOptions { DefaultRequestCulture = new RequestCulture(ptBR), SupportedCultures = new List<CultureInfo> { ptBR }, SupportedUICultures = new List<CultureInfo> { ptBR } }; //indico os parametros pra Localization dos elementos da aplicacao
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Services.CreateScope().ServiceProvider
                        .GetRequiredService<SeedingService>()
                        .Seed(); //chamo o seedingservice para a execucao do appS

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRequestLocalization(localizations); //configuro a Localization da aplicação
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}