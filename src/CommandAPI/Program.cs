using CommandAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();

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
