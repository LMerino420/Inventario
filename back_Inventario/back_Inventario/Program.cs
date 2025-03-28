using back_Inventario.Models;
using back_Inventario.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//----------------------------
//CONEXION A LA BASE DE DATOS
//----------------------------
builder.Services.AddDbContext<DbInventarioContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("conexDb"))
);

//-----------------------
//IMPLEMENTACION DE JWT
//-----------------------
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["AppSettings:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["AppSettings:Audience"],
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"]!)
                ),
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero
        };
    });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//--------------------
//ORIGENES PERMITIDOS
//--------------------
var allowedOrigin = builder.Configuration.GetValue<string>("AllowedOrigins")!.Split(",");

//--------------------
//PERMISOS DE CORS
//--------------------
builder.Services.AddCors(opc =>
{
    //Se establece politica por defecto
    opc.AddDefaultPolicy(pol =>
    {
        pol.WithOrigins(allowedOrigin).AllowAnyHeader().AllowAnyMethod();
    });
});

//REGISTRO DE SERVICIOS
builder.Services.AddScoped<IAuthService, AuthService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //Mapeo de API con SCALAR
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
