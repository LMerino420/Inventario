var builder = WebApplication.CreateBuilder(args);

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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
