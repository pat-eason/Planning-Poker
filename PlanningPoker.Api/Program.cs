using Microsoft.EntityFrameworkCore;
using PlanningPoker.Api.Hubs;
using PlanningPoker.Api.Repository;
using PlanningPoker.Core;
using System.Text.Json.Serialization;

var allowSpecificOrigins = "_allowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// configure built-in services
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: allowSpecificOrigins,
        builder => {
            builder.WithOrigins("https://localhost:8080")
                .AllowCredentials()
                .AllowAnyHeader();
        });
});
builder.Services.AddSignalR();

// Add services to the container.
builder.Services.AddScoped<ISessionsRepository, SessionsRepository>();
builder.Services.AddScoped<ISessionTasksRepository, SessionTasksRepository>();
builder.Services.AddScoped<ISessionTaskVotesRepository, SessionTaskVotesRepository>();
builder.Services.AddDbContext<PlanningPokerDbContext>(opt => opt.UseInMemoryDatabase("PlanningPoker"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors(allowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<SessionHub>("/sessionHub");
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
