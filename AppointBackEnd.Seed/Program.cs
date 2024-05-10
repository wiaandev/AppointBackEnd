using AppointBackEnd.Core;
using AppointBackEnd.Core.Entities.Auth;
using AppointBackEnd.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static async Task Main(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();

        try
        {
            await Run(host.Services);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<AppointDbContext>(opts =>
                {
                    IConfiguration config = context.Configuration;
                    opts.UseNpgsql(config.GetConnectionString("WebApiDatabase"));
                });

                // services.AddSingleton<SeedService>();

                // services.AddAuth(context.Configuration);
                // services.AddCoreServices();
            });

    private static async Task Run(IServiceProvider services)
    {

        var userManager = services.GetRequiredService<UserManager<User>>();

        // var roleManager = services.GetRequiredService<RoleManager<Role>>();
        var passwordHasher = services.GetRequiredService<IPasswordHasher<User>>();

        // var userService = services.GetRequiredService<UserService>();

        // var saleService = services.GetRequiredService<SaleService>();
        // var budgetModelService = services.GetRequiredService<BudgetModelService>();

        var seedService = services.GetRequiredService<SeedService>();
        // await using (var dbContext = await services.GetRequiredService<IDbContextFactory<AppDbContext>>().CreateDbContextAsync())
        // {
        //     await seedService.Seed(dbContext, userManager, passwordHasher, roleManager, userService, "dev");
        // }
    }
}