using BlazorApp_Tricia.Data;
using BlazorApp_Tricia.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<QuestionProviderService>();
builder.Services.AddSingleton<StudentService>();
builder.Services.AddSingleton<WebsiteService>();
builder.Services.AddSingleton<QuestionService>();
//builder.Services.AddSingleton<>
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

var connectionString = builder.Configuration.GetSection("Info")["ConnectionString"];
Console.WriteLine(connectionString);
var websiteService = app.Services.GetService<WebsiteService>();
var studentService = app.Services.GetService<StudentService>();
var questionService = app.Services.GetService<QuestionService>();

websiteService?.Init(connectionString);
studentService?.Init(connectionString);
questionService?.LoadQuestions("./data/Questions.json");
questionService?.LoadBatQuestions("./data/BatQuestions.json");
app.Run();


