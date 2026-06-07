using Entites;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PortfolioDB>(optionsAction =>
{
    optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("DedaultConnection"));
});
var app = builder.Build();

app.MapControllers();
app.UseStaticFiles();

app.Run();
