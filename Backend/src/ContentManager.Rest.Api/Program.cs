using ContentManager.Application;
using ContentManager.Infrastructure;
using ContentManager.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Application();
builder.Services.Infrastructure(builder.Configuration.GetConnectionString("ContentManager")!);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    scope.ServiceProvider.GetRequiredService<ContentManagerDbContext>().Database.Migrate();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();