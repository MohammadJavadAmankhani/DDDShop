using DDDShop.Infrastructure.Orders;
using Microsoft.EntityFrameworkCore;
using DDDShop.Domain.Aggregates.BillingOrders.Interfaces;
using DDDShop.Domain.Aggregates.ShippingOrders.Interfaces;
using DDDShop.Domain.Aggregates.Orders.Interfaces;
using DDDShop.Infrastructure.BillingOrders;
using DDDShop.Infrastructure.ShippingOrders;
using DDDShop.Infrastructure.Orders;
using DDDShop.Application.Common.Events;
using System.Reflection;
using MediatR;



var builder = WebApplication.CreateBuilder(args);

// 🔧 Add DbContext
builder.Services.AddDbContext<OrdersDbContext>(options =>
    options.UseSqlite("Data Source=dddshop.db"));

builder.Services.AddMediatR(typeof(Program).Assembly);


// 💉 Dependency Injection
builder.Services.AddScoped<IOrderRepository, EfOrderRepository>();
builder.Services.AddScoped<IBillingOrderRepository, EfBillingOrderRepository>();
builder.Services.AddScoped<IShippingOrderRepository, EfShippingOrderRepository>();
builder.Services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<OrdersDbContext>();
    DDDShop.Infrastructure.SeedData.DbInitializer.Seed(context);
}


// ✅ Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
