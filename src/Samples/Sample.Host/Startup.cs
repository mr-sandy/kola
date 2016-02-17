using Microsoft.Owin;

using Sample.Host;

[assembly: OwinStartup(typeof(Startup))]

namespace Sample.Host
{
    using System.Collections.Generic;
    using System.IdentityModel.Tokens;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.IdentityModel.Protocols;
    using Microsoft.Owin.Extensions;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.OpenIdConnect;

    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseCookieAuthentication(new CookieAuthenticationOptions { AuthenticationType = "Cookies" });
            app.UseOpenIdConnectAuthentication(this.OpenIdConnectOptions());
            app.Use(typeof(StatusCodeLoggingMiddleware));
            app.UseNancy();
            app.UseStageMarker(PipelineStage.MapHandler);
        }

        private OpenIdConnectAuthenticationOptions OpenIdConnectOptions()
        {
            return new OpenIdConnectAuthenticationOptions
            {
                ClientId = "linncouk",
                Authority = "https://localhost:44302/core",
                RedirectUri = "https://localhost:44310/",
                ResponseType = "id_token token",
                Scope = "openid profile associations permissions",

                SignInAsAuthenticationType = "Cookies",

                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    SecurityTokenValidated = n =>
                    {
                        if (!string.IsNullOrEmpty(n.ProtocolMessage.AccessToken))
                        {
                            n.AuthenticationTicket.Identity.AddClaim(new Claim("access_token", n.ProtocolMessage.AccessToken));
                        }

                        if (!string.IsNullOrEmpty(n.ProtocolMessage.IdToken))
                        {
                            n.AuthenticationTicket.Identity.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));
                        }

                        return Task.FromResult(0);
                    },

                    AuthorizationCodeReceived = n => Task.FromResult(0),
                    RedirectToIdentityProvider = n =>
                    {
                        // if signing out, add the id_token_hint
                        if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.LogoutRequest)
                        {
                            var idTokenHint = n.OwinContext.Authentication.User.FindFirst("id_token");

                            if (idTokenHint != null)
                            {
                                n.ProtocolMessage.IdTokenHint = idTokenHint.Value;
                                n.ProtocolMessage.RedirectUri = "http://localhost:44310";
                            }
                        }

                        return Task.FromResult(0);
                    }
                }
            };
        }
    }

    //public class AlwaysUnauthorisedMiddleware : OwinMiddleware
    //{
    //    public AlwaysUnauthorisedMiddleware(OwinMiddleware next) : base(next)
    //    {
    //    }

    //    public override async Task Invoke(IOwinContext context)
    //    {
    //        context.Response.StatusCode = 401;
    //    }
    //}
}
