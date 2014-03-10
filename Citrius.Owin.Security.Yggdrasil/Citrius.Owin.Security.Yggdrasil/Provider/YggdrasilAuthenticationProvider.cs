using System;
using System.Threading.Tasks;

namespace Citrius.Owin.Security.Yggdrasil
{
    public class YggdrasilAuthenticationProvider : IYggdrasilAuthenticationProvider
    {
        public YggdrasilAuthenticationProvider()
        {
            OnAuthenticated = context => Task.FromResult<object>(null);
            OnReturnEndpoint = context => Task.FromResult<object>(null);
        }

        public Func<YggdrasilAuthenticatedContext, Task> OnAuthenticated { get; set; }

        public Func<YggdrasilReturnEndpointContext, Task> OnReturnEndpoint { get; set; }

        public virtual Task Authenticated(YggdrasilAuthenticatedContext context)
        {
            return OnAuthenticated(context);
        }

        public virtual Task ReturnEndpoint(YggdrasilReturnEndpointContext context)
        {
            return OnReturnEndpoint(context);
        }
    }
}
