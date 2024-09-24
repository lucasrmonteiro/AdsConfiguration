using System.Net;
using AdsConfiguration.Application.DI;
using AdsConfiguration.Application.Interfaces;
using AdsConfiguration.Domain.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext();
builder.Services.AddRepository();
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/ads", async (IAdsService service) =>
    {
        return await service.GetAds();
       
    })
    .WithName("ads")
    .WithOpenApi();

app.MapPost("/save/ads", (IAdsService service , Ads ad) =>
    {
        return service.UpsertAds(ad);
    })
    .WithName("saveAd")
    .WithOpenApi();

app.Run();
