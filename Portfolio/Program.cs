using Entites;
using Microsoft.EntityFrameworkCore;
using Service;
using ServiceContract;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPostService , PostService>();
builder.Services.AddDbContext<PortfolioDB>(optionsAction =>
{
    optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("DedaultConnection"));
});
var app = builder.Build();

app.MapControllers();
app.UseStaticFiles();

app.Run();
