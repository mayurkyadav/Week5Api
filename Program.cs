
namespace Week5Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();



app.UseAuthorization();

app.MapControllers();

// 
app.MapGet("/hello", () => "Hello From Render API running .NET 9/10");

app.Run();

    }
}
