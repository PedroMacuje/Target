using Cadastro.Infrastructure.Data.Common;
using Cadastro.Infrastructure.ExtensionMethods;
using Cadastro.Infrastructure.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao cont�iner
builder.Services.AddRepositories().AddServices();

builder.Services.AddAutoMapper(typeof(AutoMapping));

builder.Services.AddDbContext<RegisterContext>(options =>
    options.UseInMemoryDatabase("Register"));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura��o do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();