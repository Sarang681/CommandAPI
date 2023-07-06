using CommandAPI.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var strBuilder = new NpgsqlConnectionStringBuilder(builder.Configuration.GetConnectionString("PostgreSqlConnection"))
{
    Username = builder.Configuration["UserID"],
    Password = builder.Configuration["Password"]
};
builder.Services.AddDbContext<CommandContext>(opt => opt.UseNpgsql(
    strBuilder.ConnectionString
));

builder.Services.AddControllers();
builder.Services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>();

var app = builder.Build();

if (builder.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
