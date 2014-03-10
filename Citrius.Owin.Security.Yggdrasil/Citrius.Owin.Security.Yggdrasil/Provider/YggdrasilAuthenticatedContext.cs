using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;
using Newtonsoft.Json.Linq;
using System;
using System.Security.Claims;

namespace Citrius.Owin.Security.Yggdrasil
{
    public class YggdrasilAuthenticatedContext : BaseContext
    {
        public YggdrasilAuthenticatedContext(IOwinContext context, JObject payload, string accessToken)
            : base(context)
        {
            if (payload == null)
            {
                throw new ArgumentNullException("payload");
            }

            //User = payload;
            AccessToken = TryGetValue(payload, "accessToken");

            //JToken userId = User["id"];
            //if (userId == null)
            //{
            //    throw new ArgumentException("The user does not have an id.", "payload");
            //}

            SelectedProfile = TryGetValue(payload, "selectedProfile");
            AvailableProfiles = TryGetValue(payload, "availableProfiles");

            Id = TryGetValue(JObject.Parse(SelectedProfile), "id");
            Name = TryGetValue(JObject.Parse(SelectedProfile), "name");
        }

        //public JObject User { get; private set; }
        public string AccessToken { get; private set; }
        public string SelectedProfile { get; private set; }
        public string AvailableProfiles { get; private set; }
        public string Id { get; private set; }
        public string Name { get; private set; }

        public ClaimsIdentity Identity { get; set; }
        public AuthenticationProperties Properties { get; set; }

        private static string TryGetValue(JObject payload, string propertyName)
        {
            JToken value;
            return payload.TryGetValue(propertyName, out value) ? value.ToString() : null;
        }
    }
}
