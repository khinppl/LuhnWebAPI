using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Define the API version and metadata
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1.0",
        Title = "LuhnWebAPI",
        Description = "Luhn Web API V1.0"
    });

    // Use full type names for schema IDs to avoid naming conflicts
    c.CustomSchemaIds(type => type.FullName);

    // Include XML comments from the generated XML documentation file
    // This adds descriptions from XML comments in code to the Swagger documentation
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

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
