using SevenWinBackend.Site.Library;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string policyName = "CorsPolicy";
builder.Services.AddCors(p => p.AddPolicy(policyName, builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policyName);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
