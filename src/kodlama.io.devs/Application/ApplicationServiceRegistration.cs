using Application.Features.Frameworks.Rules;
using Application.Features.Auths.Rules;
using Application.Features.Languages.Rules;
using Application.Services.AuthService;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Features.GithubAccounts.Rules;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<LanguageBusinessRules>();
            services.AddScoped<FrameworkBusinessRules>();
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<GithubAccountBusinessRules>();
            services.AddScoped<IAuthService, AuthManager>();


            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));  
           

            return services;

        }
    }
}
