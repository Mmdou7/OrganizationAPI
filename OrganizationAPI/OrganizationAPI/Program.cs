using Organization.Application.Configuration;
using Organization.Infrastructure.Configuration;
using Organization.Presentation.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

// register services of all layers 
builder.Services
    .AddApplication()
    .AddPresentation()
    .AddInfrastructure();

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
