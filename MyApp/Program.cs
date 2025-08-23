var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// ADDS OUR CONTROLLERS AND VIEWS
builder.Services.AddControllersWithViews();

// BUILDS THE SERVICES, WEB APPLICATION
var app = builder.Build();

// Configure the HTTP request pipeline.
// CONDITIONS FOR DEVELOPMENT MODE
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// RE-ROUTES ALL HTTP REQUESTS TO HTTPS
app.UseHttpsRedirection();

// ALLOWS PROJECT TO USE ROUTING TO PAGES
app.UseRouting();

// SETS UP AUTHORIZATION FOR ENDPOINTS
app.UseAuthorization();

// LOADS THE STATIC ASSETS SUCH AS IMAGES
app.MapStaticAssets();

// SETUP THE PATTERN FOR OUR CONTROLLER URL
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
