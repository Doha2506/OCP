using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OCP.Interfaces;
using OCP.Models;
using OCP.Services;


var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<IDiscountFactory, DiscountFactory>();
    })
    .Build();

// Get service from DI container
var discountFactoryService = host.Services.GetRequiredService<IDiscountFactory>();

IDiscountCalculator vipDiscount = discountFactoryService.GetCalculator(UserType.VIP);

Console.WriteLine("VIP Discount : " + vipDiscount.GetDiscount());

IDiscountCalculator standardDiscount = discountFactoryService.GetCalculator(UserType.Standard);

Console.WriteLine("Standard Discount : " + standardDiscount.GetDiscount());

IDiscountCalculator premimumDiscount = discountFactoryService.GetCalculator(UserType.Premium);

Console.WriteLine("Premimum Discount : " + premimumDiscount.GetDiscount());

discountFactoryService.Register(UserType.Studend, () => new StudentDiscount());

IDiscountCalculator studentDiscount = discountFactoryService.GetCalculator(UserType.Studend);

Console.WriteLine("Student Discount : " + studentDiscount.GetDiscount());