using WebApplicationCors1.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(cors=>
{
    cors.AddPolicy("Policy_1",
        builder => builder.WithOrigins("http://localhost:5205")
                          .WithMethods("GET"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc(options => options
.Filters.Add(new AllowCorsAttribute()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

//app.UseCors("Policy_1");



app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
