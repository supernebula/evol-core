using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Evol.TMovie.Manage.Models.Identity;
using Evol.TMovie.Manage.Core.Identity;

namespace Evol.TMovie.Manage
{
    public partial class Startup
    {
        public void ConfigureIdentity(IServiceCollection services)
        {
            // 这个就是被 Identity 使用的
            services.AddAuthentication(options =>
            {
                // This is the Default value for ExternalCookieAuthenticationScheme
                options.SignInScheme = new IdentityCookieOptions().ExternalCookieAuthenticationScheme;
            });

            // 注册 IHttpContextAccessor ，会用到
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUserStore<AppUser>, AppUserStore>();
            services.AddScoped<IRoleStore<AppRole>, AppRoleStore>();

            // Identity services
            services.TryAddSingleton<IdentityMarkerService>();
            services.TryAddScoped<IUserValidator<AppUser>, UserValidator<AppUser>>();
            services.TryAddScoped<IPasswordValidator<AppUser>, PasswordValidator<AppUser>>();
            services.TryAddScoped<IPasswordHasher<AppUser>, DefaultPasswordHasher>();
            services.TryAddScoped<ILookupNormalizer, UpperInvariantLookupNormalizer>();
            services.TryAddScoped<IRoleValidator<AppUser>, RoleValidator<AppUser>>();

            // 错误描述信息
            services.TryAddScoped<IdentityErrorDescriber>();
            services.TryAddScoped<ISecurityStampValidator, SecurityStampValidator<AppUser>>();

            //身份当事人工厂
            services.TryAddScoped<IUserClaimsPrincipalFactory<AppUser>, UserClaimsPrincipalFactory<AppUser, AppRole>>();

            //三大对象
            services.TryAddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            services.TryAddScoped<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.TryAddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();
        }

    }
}
