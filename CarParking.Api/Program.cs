using CarParking.Api;
using CarParking.DataAccess.Context;
using CarParking.DataAccess.Repositories.Interfaces;
using CarParking.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using CarParking.Services.Services.Interfaces;
using CarParking.Services.Services;
using CarParking.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddAutoMapper(typeof(ApiMappingProfile));

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.RoutePrefix = string.Empty;
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");

    });
}

//app.UseRouting();
app.MapControllers();
app.Run();

