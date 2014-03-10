using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Citrius.Owin.Security.Yggdrasil
{
    public class YggdrasilAuthenticationOptions : AuthenticationOptions
    {
        public const string Scheme = "Yggdrasil";

        public YggdrasilAuthenticationOptions()
            : base(Scheme)
        {
            Caption = Scheme;
            CallbackPath = "/authenticate";
            AuthenticationMode = AuthenticationMode.Passive;
            BackchannelTimeout = TimeSpan.FromSeconds(60);
            Scope = new List<string>();
        }

        public string ClientToken { get; set; }

        //public string ClientSecret { get; set; }

        public ICertificateValidator BackchannelCertificateValidator { get; set; }
        public TimeSpan BackchannelTimeout { get; set; }
        public HttpMessageHandler BackchannelHttpHandler { get; set; }

        public string Caption
        {
            get { return Description.Caption; }
            set { Description.Caption = value; }
        }

        public string CallbackPath { get; set; }

        public string SignInAsAuthenticationType { get; set; }

        public IYggdrasilAuthenticationProvider Provider { get; set; }

        public ISecureDataFormat<AuthenticationProperties> StateDataFormat { get; set; }

        public IList<string> Scope { get; private set; }

    }
}
