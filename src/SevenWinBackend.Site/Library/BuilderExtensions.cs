using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using SevenWinBackend.Application.Data;
using SevenWinBackend.Application.Options;
using SevenWinBackend.Application.Services.Data;
using SevenWinBackend.Data;
using SevenWinBackend.Domain.Common;
using System.Text;

namespace SevenWinBackend.Site.Library
{
    public static class BuilderExtensions
    {
        public static void AddAuthentication(this WebApplicationBuilder builder)
        {
            var issuer = builder.Configuration["Jwt:Issuer"];
            var audience = builder.Configuration["Jwt:Audience"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = key,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true
                    };
                });
        }
        /// <summary>
        /// 配置模型验证响应
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigModelValidationResponse(this WebApplicationBuilder builder)
        {
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
                        success = false,
                        message = errors.FirstOrDefault()!,
                        data = ""
                    };
                    return new BadRequestObjectResult(result);
                };
            });
        }

        public static void AddSiteServices(this WebApplicationBuilder builder)
        {
            builder.Services.TryAddScoped<SettingOptions>();
            builder.Services.TryAddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
            builder.Services.TryAddScoped<AccountService>();
        }
    }
}
