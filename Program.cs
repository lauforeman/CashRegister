using CashRegister.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
{
    policy.WithOrigins(Environment.GetEnvironmentVariable("ALLOWED_ORIGINS")!.Split(",")).AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddDbContext<CashRegisterContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || Boolean.Parse(Environment.GetEnvironmentVariable("ENABLE_SWAGGER")!))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();