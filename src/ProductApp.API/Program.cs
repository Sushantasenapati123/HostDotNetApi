using ProductApp.Application;
using ProductApp.Infrastructure;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add Clean Architecture layers services
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// Add Controllers
builder.Services.AddControllers();

// Add CORS services
builder.Services.AddCors(options =>
{
    var corsOrigins = builder.Configuration.GetValue<string>("CorsOrigins")
        ?? "http://localhost:4200";

    var origins = corsOrigins.Split(',', StringSplitOptions.RemoveEmptyEntries);

    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins(origins)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomOperationIds(apiDesc =>
        apiDesc.TryGetMethodInfo(out System.Reflection.MethodInfo methodInfo) ? methodInfo.Name : null);
});

var app = builder.Build();

app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test CRUD API v1");
        c.RoutePrefix = string.Empty; // Serve Swagger UI at the root
        c.DisplayOperationId(); // Display action/method names next to routes
    });


// app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
