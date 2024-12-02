using CarParking.Api;
using CarParking.DataAccess.Context;
using CarParking.DataAccess.Repositories.Interfaces;
using CarParking.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using CarParking.Services.Services.Interfaces;
using CarParking.Services.Services;
using CarParking.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
builder.Services.AddTransient<IVehicleService, VehicleService>();

builder.Services.AddTransient<IZoneRepository, ZoneRepository>();
builder.Services.AddTransient<IZoneService, ZoneService>();

builder.Services.AddTransient<IParkingRepository, ParkingReposirory>();
builder.Services.AddTransient<IParkingPriceCalculator, ParkingPriceCalculator>();
builder.Services.AddTransient<IParkingService, ParkingService>();

builder.Services.AddAutoMapper(typeof(ApiMappingProfile));
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Standart Authorization header using the Bearer scheme (\"bearer {token}\"\")",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

builder.Services.AddCors();

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
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(builder => { builder.SetIsOriginAllowed((origin) => { return origin == "http://localhost:5173"; }); builder.AllowAnyHeader(); builder.AllowAnyMethod(); });
//app.UseRouting();
app.MapControllers();
app.Run();

