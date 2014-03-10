using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;

namespace Citrius.Owin.Security.Yggdrasil
{
    public class YggdrasilReturnEndpointContext : ReturnEndpointContext
    {
        public YggdrasilReturnEndpointContext(
            IOwinContext context,
            AuthenticationTicket ticket)
            : base(context, ticket)
        {
        }
    }
}
