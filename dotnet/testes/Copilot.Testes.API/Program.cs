using Copilot.Testes.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();

app.UseSwaggerUI(options =>
           options.SwaggerEndpoint("/openapi/v1.json", "nome da api"));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Configure();

app.Run();


