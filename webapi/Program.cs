using Microsoft.EntityFrameworkCore;
using Infrastructure.DataBase;
using Core.Interfaces;
using webapi.util;

var builder = WebApplication.CreateBuilder(args);
var DbConnection = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreContext>(x => x.UseSqlite(DbConnection));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped((typeof(IGenericRepository<>)),typeof(GenericRepository<>));
builder.Services.AddAutoMapper(typeof(MappingProfiles));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
