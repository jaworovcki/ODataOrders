using Microsoft.EntityFrameworkCore;
using ODataOrders.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// register ODataOrdersContext
builder.Services.AddDbContext<ODataOrdersContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
