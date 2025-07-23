using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OCP.Interfaces;
using OCP.Services;


var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<IDiscountFactory, DiscountFactory>();
        services.AddTransient<IDiscountCalculator, PremiumDiscount>();
        services.AddTransient<IDiscountCalculator, StandardDiscount>();
        services.AddTransient<IDiscountCalculator, VIPDiscount>();
        services.AddTransient<IDiscountCalculator, StudentDiscount>();
    })
    .Build();

// Get service from DI container
var discountFactoryService = host.Services.GetRequiredService<IDiscountFactory>();

IDiscountCalculator vipDiscount = discountFactoryService.GetCalculator("VIP");

Console.WriteLine("VIP Discount : " + vipDiscount.GetDiscount());

IDiscountCalculator standardDiscount = discountFactoryService.GetCalculator("Standard");

Console.WriteLine("Standard Discount : " + standardDiscount.GetDiscount());

IDiscountCalculator premimumDiscount = discountFactoryService.GetCalculator("Premium");

Console.WriteLine("Premimum Discount : " + premimumDiscount.GetDiscount());

discountFactoryService.Register("Student", () => new StudentDiscount());

IDiscountCalculator StudentDiscount = discountFactoryService.GetCalculator("Student");

Console.WriteLine("Student Discount : " + StudentDiscount.GetDiscount());