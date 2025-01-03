using Api.Funcionalidaades.Clientes;
using Api.Funcionalidades.Carritos;
using Api.Funcionalidades.Clientes.Categoria;
using Api.Funcionalidades.ItemCarritos;
using Api.Funcionalidades.HistorialPrecioEndPoint;

using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("aplicacion_db");


builder.Services.AddDbContext<AplicacionDbContext>(opciones =>
    opciones.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 30))));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHistorialPrecioService, HistorialPrecioService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IItemCarritoService, ItemCarritoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ICarritoService, CarritoService>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();


    app.UseSwaggerUI(options => options.EnableTryItOutByDefault());
}

app.UseHttpsRedirection();

//Endpoint para que nos redireccione a Swagger directamente.
app.MapGet("/", () => Results.Redirect("/swagger"));


using (var scope = app.Services.CreateScope())
{
    var contexto = scope.ServiceProvider.GetRequiredService<AplicacionDbContext>();
    contexto.Database.EnsureCreated();
}

//Metodo para agrupar nuestros endpoints.
app.MapGroup("/Api")
    .MapClienteEndPoints()
    .WithTags("Cliente");

app.MapGroup("/Api")
    .MapProductoEndPoints()
    .WithTags("Producto");

app.MapGroup("/Api")
    .MapitemcarritoEndPoints()
    .WithTags("ItemCarrito");

app.MapGroup("/Api")
    .MapCategoriaEndPoints()
    .WithTags("Categoria");

app.MapGroup("/Api")
    .MapCarritoEndpoints()
    .WithTags("Carrito");

app.MapGroup("/Api")
    .MapHistorialPrecioEndPoints()
    .WithTags("HistorialPrecio");


app.Run();




