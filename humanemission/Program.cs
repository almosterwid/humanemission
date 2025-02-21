using humanemission.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using humanemission.Data;
using Blazorise;
using Blazorise.AntDesign;
using Microsoft.AspNetCore.Components;

namespace humanemission
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContextFactory<humanemissionContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("humanemissionContext") ?? throw new InvalidOperationException("Connection string 'humanemissionContext' not found.")));

            builder.Services.AddQuickGridEntityFrameworkAdapter();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddFluentUIComponents();
            AddBlazorise(builder.Services);

            //builder.Services.AddScoped<NavigationManager>();



            //builder.Services.AddSingleton<IIdGenerator, DefaultIdGenerator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
    app.UseMigrationsEndPoint();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();

            void AddBlazorise(IServiceCollection services)
            {
                services
                    .AddBlazorise();
                services
                    .AddAntDesignProviders();
                    //.AddFontAwesomeIcons();
            }

        }
    }
}
