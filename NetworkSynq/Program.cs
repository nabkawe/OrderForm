




using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

if (!Directory.Exists(@"C:\db"))
{
    Directory.CreateDirectory(@"C:\db");
}
// add cors policy
var corsPolicy = new Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
    .Build();




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", corsPolicy);
});
var app = builder.Build();
app.UseCors("CorsPolicy");


//app.UseHttpsRedirection();

//app.UseAuthorization();
app.MapControllers();

try
{
    app.Run();
}
catch (System.Exception)
{
    
}
