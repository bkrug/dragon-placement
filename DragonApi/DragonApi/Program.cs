using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DragonContext>(options =>
    options.UseSqlite(builder.Configuration["ConnectionStrings:SQLiteDefault"]),
    ServiceLifetime.Scoped);

builder.Services.AddScoped<IDragonRepository, DragonRepository>();
builder.Services.AddScoped<IGenericRepository<Dragon>, GenericRepository<Dragon>>();
builder.Services.AddScoped<IDragonLogic, DragonLogic>();

var app = builder.Build();

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