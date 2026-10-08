using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// הוספת שירותי OpenAPI (מובנה ב-.NET)
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // מיפוי ה-Scalar (ברירת המחדל היא הנתיב /scalar)
    app.MapScalarApiReference();
}

app.Run();