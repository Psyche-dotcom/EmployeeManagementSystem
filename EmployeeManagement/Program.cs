global using Microsoft.AspNetCore.Components.Authorization;
using EmployeeManagement;
using EmployeeManagement.Service;
using EmploymentManagement.API.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient<IEmployeeServiceHttp, EmployeeServiceHttp>(client => client.BaseAddress = new Uri("https://localhost:7080/"));
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthenticationCore();
builder.Services.AddHttpClient<IDepartmentServiceHttp, DepartmentServiceHttp>(client => client.BaseAddress = new Uri("https://localhost:7080/"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
