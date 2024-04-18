using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesClubRanking.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// if (builder.Environment.IsDevelopment())
// {
//     builder.Services.AddDbContext<RazorPagesClubRankingContext>(options =>
//         options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesClubRankingContext")));
// }
// else
// {
//     builder.Services.AddDbContext<RazorPagesClubRankingContext>(options =>
//         options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionClubRankigContext")));
// }
builder.Services.AddDbContext<RazorPagesClubRankingContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesClubRankingContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesClubRankingContext' not found.")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
