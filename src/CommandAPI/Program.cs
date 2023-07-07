using CommandAPI.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
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

builder.Services.AddControllers().AddNewtonsoftJson(s => 
{
    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});
builder.Services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
