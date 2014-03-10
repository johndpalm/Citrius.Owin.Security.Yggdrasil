using System;
using Microsoft.Owin.Security;
using Citrius.Owin.Security.Yggdrasil;

namespace Owin
{
    public static class YggdrasilAuthenticationExtensions
    {
        public static IAppBuilder UseYggdrasilAuthentication(this IAppBuilder app, YggdrasilAuthenticationOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            app.Use(typeof(YggdrasilAuthenticationMiddleware), app, options);
            return app;
        }

        public static IAppBuilder UseYggdrasilAuthentication(
            this IAppBuilder app,
            string clientToken)
        {
            return UseYggdrasilAuthentication(
                app,
                new YggdrasilAuthenticationOptions
                {
                    ClientToken = clientToken
                    //,   ClientSecret = clientSecret
                });
        }
    }
}
