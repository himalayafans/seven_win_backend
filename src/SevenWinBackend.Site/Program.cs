using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SevenWinBackend.Domain.Common;
using SevenWinBackend.Site.Library;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = actionContext =>
    {
        //获取验证失败的模型字段 
        var errors = actionContext.ModelState
            .Where(s => s.Value != null && s.Value.ValidationState == ModelValidationState.Invalid)
            .SelectMany(s => s.Value!.Errors.ToList())
            .Select(e => e.ErrorMessage)
            .ToList();

        // 统一返回格式
        var result = new ApiResult<string>()
        {
            Success = false,
            Message = errors.FirstOrDefault()!,
            Content = ""
        };
        return new BadRequestObjectResult(result);
    };
});
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
