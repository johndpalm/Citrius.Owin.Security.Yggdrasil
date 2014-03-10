using System.Threading.Tasks;

namespace Citrius.Owin.Security.Yggdrasil
{
    public interface IYggdrasilAuthenticationProvider
    {
        Task Authenticated(YggdrasilAuthenticatedContext context);
        Task ReturnEndpoint(YggdrasilReturnEndpointContext context);
    }
}
