


using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

if (!Directory.Exists(@"C:\db"))
{
    Directory.CreateDirectory(@"C:\db");
}
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var app = builder.Build();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

try
{
    app.Run();
}
catch (System.Exception)
{

}

    