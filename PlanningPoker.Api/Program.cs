using Microsoft.EntityFrameworkCore;
using PlanningPoker.Api.Repository;
using PlanningPoker.Core;

var allowSpecificOrigins = "_allowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// configure built-in services
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: allowSpecificOrigins,
        builder => {
            builder.WithOrigins("https://localhost:8080")
                .AllowAnyHeader();
        });
});

// Add services to the container.
builder.Services.AddScoped<ISessionsRepository, SessionsRepository>();
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

app.UseCors(allowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
