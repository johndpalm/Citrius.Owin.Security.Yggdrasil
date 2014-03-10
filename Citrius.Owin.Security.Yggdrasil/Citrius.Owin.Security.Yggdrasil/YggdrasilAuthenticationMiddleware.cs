using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Infrastructure;
using Owin;
using System;
using System.Net.Http;

namespace Citrius.Owin.Security.Yggdrasil
{
    public class YggdrasilAuthenticationMiddleware : AuthenticationMiddleware<YggdrasilAuthenticationOptions>
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;

        public YggdrasilAuthenticationMiddleware(
            OwinMiddleware next,
            IAppBuilder app,
            YggdrasilAuthenticationOptions options)
            : base(next, options)
        {
            if (string.IsNullOrWhiteSpace(Options.ClientToken))
            {
                throw new ArgumentException("The 'ClientToken' must be provided.");
            }

            _logger = app.CreateLogger<YggdrasilAuthenticationMiddleware>();

            if (Options.Provider == null)
            {
                Options.Provider = new YggdrasilAuthenticationProvider();
            }


        }

        protected override AuthenticationHandler<YggdrasilAuthenticationOptions> CreateHandler()
        {
            return new YggdrasilAuthenticationHandler(_httpClient, _logger);
        }


    }
}
