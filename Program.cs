using Rotativa.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// register in-memory repo
builder.Services.AddSingleton<IEmployeeRepository, InMemoryEmployeeRepository>();

var app = builder.Build();

// Rotativa needs path to wwwroot and folder name with wkhtmltopdf
RotativaConfiguration.Setup(app.Environment.WebRootPath, "Rotativa");




if (!app.Environment.IsDevelopment())
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
    pattern: "{controller=Employees}/{action=Index}/{id?}");

app.Run();
