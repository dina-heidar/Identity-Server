﻿//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.DependencyInjection.Extensions;
//using System;

//namespace Identity.ExtensionStore.IdentityPermission
//{
//    public static class IdentityExtensionServiceCollectionExtensions
//    {
//        /// <summary>
//        /// Adds the default identity system configuration for the specified User and Role types.
//        /// </summary>
//        /// <typeparam name="TUser">The type representing a User in the system.</typeparam>
//        /// <typeparam name="TRole">The type representing a Role in the system.</typeparam>
//        /// <param name="services">The services available in the application.</param>
//        /// <returns>An <see cref="IdentityBuilder"/> for creating and configuring the identity system.</returns>
//        public static IdentityExtensionBuilder AddIdentityExtension<TUser, TRole, TPermission>(
//            this IServiceCollection services)
//            where TUser : class
//            where TRole : class
//            where TPermission : class
//            => services.AddIdentityExtension<TUser, TRole, TPermission>(setupAction: null);

//        /// <summary>
//        /// Adds and configures the identity system for the specified User and Role types.
//        /// </summary>
//        /// <typeparam name="TUser">The type representing a User in the system.</typeparam>
//        /// <typeparam name="TRole">The type representing a Role in the system.</typeparam>
//        /// <param name="services">The services available in the application.</param>
//        /// <param name="setupAction">An action to configure the <see cref="IdentityOptions"/>.</param>
//        /// <returns>An <see cref="IdentityBuilder"/> for creating and configuring the identity system.</returns>
//        public static IdentityExtensionBuilder AddIdentityExtension<TUser, TRole, TPermission>(
//            this IServiceCollection services,
//            Action<IdentityOptions> setupAction)
//            where TUser : class
//            where TRole : class
//            where TPermission : class
//        {
//            // Services used by identity
//            services.AddAuthentication(options =>
//            {
//                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
//                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
//                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
//            })
//            .AddCookie(IdentityConstants.ApplicationScheme, o =>
//            {
//                o.LoginPath = new PathString("/Account/Login");
//                o.Events = new CookieAuthenticationEvents
//                {
//                    OnValidatePrincipal = SecurityStampValidator.ValidatePrincipalAsync
//                };
//            })
//            .AddCookie(IdentityConstants.ExternalScheme, o =>
//            {
//                o.Cookie.Name = IdentityConstants.ExternalScheme;
//                o.ExpireTimeSpan = TimeSpan.FromMinutes(5);
//            })
//            .AddCookie(IdentityConstants.TwoFactorRememberMeScheme, o =>
//            {
//                o.Cookie.Name = IdentityConstants.TwoFactorRememberMeScheme;
//                o.Events = new CookieAuthenticationEvents
//                {
//                    OnValidatePrincipal = SecurityStampValidator.ValidateAsync<ITwoFactorSecurityStampValidator>
//                };
//            })
//            .AddCookie(IdentityConstants.TwoFactorUserIdScheme, o =>
//            {
//                o.Cookie.Name = IdentityConstants.TwoFactorUserIdScheme;
//                o.ExpireTimeSpan = TimeSpan.FromMinutes(5);
//            });

//            // Hosting doesn't add IHttpContextAccessor by default
//            services.AddHttpContextAccessor();
//            // Identity services
//            services.TryAddScoped<IUserValidator<TUser>, UserValidator<TUser>>();
//            services.TryAddScoped<IPasswordValidator<TUser>, PasswordValidator<TUser>>();
//            services.TryAddScoped<IPasswordHasher<TUser>, PasswordHasher<TUser>>();
//            services.TryAddScoped<ILookupNormalizer, UpperInvariantLookupNormalizer>();
//            services.TryAddScoped<IRoleValidator<TRole>, RoleValidator<TRole>>();
//            // No interface for the error describer so we can add errors without rev'ing the interface
//            services.TryAddScoped<IdentityErrorDescriber>();
//            services.TryAddScoped<ISecurityStampValidator, SecurityStampValidator<TUser>>();
//            services.TryAddScoped<ITwoFactorSecurityStampValidator, TwoFactorSecurityStampValidator<TUser>>();
//            services.TryAddScoped<IUserClaimsPrincipalFactory<TUser>, UserClaimsPrincipalFactory<TUser, TRole>>();
//            services.TryAddScoped<IUserConfirmation<TUser>, DefaultUserConfirmation<TUser>>();
//            services.TryAddScoped<UserManager<TUser>>();
//            services.TryAddScoped<SignInManager<TUser>>();
//            services.TryAddScoped<RoleManager<TRole>>();

//            if (setupAction != null)
//            {
//                services.Configure(setupAction);
//            }

//            return new IdentityExtensionBuilder(typeof(TUser), typeof(TRole), typeof(TPermission), services);
//        }

//        /// <summary>
//        /// Configures the application cookie.
//        /// </summary>
//        /// <param name="services">The services available in the application.</param>
//        /// <param name="configure">An action to configure the <see cref="CookieAuthenticationOptions"/>.</param>
//        /// <returns>The services.</returns>
//        public static IServiceCollection ConfigureApplicationCookie(this IServiceCollection services, Action<CookieAuthenticationOptions> configure)
//            => services.Configure(IdentityConstants.ApplicationScheme, configure);

//        /// <summary>
//        /// Configure the external cookie.
//        /// </summary>
//        /// <param name="services">The services available in the application.</param>
//        /// <param name="configure">An action to configure the <see cref="CookieAuthenticationOptions"/>.</param>
//        /// <returns>The services.</returns>
//        public static IServiceCollection ConfigureExternalCookie(this IServiceCollection services, Action<CookieAuthenticationOptions> configure)
//            => services.Configure(IdentityConstants.ExternalScheme, configure);
//    }
//}
