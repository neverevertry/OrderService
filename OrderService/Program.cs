using DataAccess.Context;
using DataAccess.Repositories;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Interface;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ConString")));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql("Host=localhost;Port=5433;Database=order;Username=postgres;Password="));
builder.Services.AddTransient<IOrderRepository, EFOrderRepository>();
builder.Services.AddTransient<IOrderService, Service.Services.OrderService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

