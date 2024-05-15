using Store.Application.Contracts.Product;
using Store.Application.Contracts.Supplier;
using Store.Application.Contracts.Unit;
using Store.Application.Implementation;
using Store.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddScoped<IUnitAppService, UnitAppService>();
builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddScoped<ISupplierAppService, SupplierAppService>();
var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
