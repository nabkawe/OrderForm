


using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var app = builder.Build();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
    