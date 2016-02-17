
namespace Sample.Host.Modules
{
    using Nancy;
    using Nancy.Responses;
    using Nancy.Security;

    public class AuthModule : NancyModule
    {
        public AuthModule()
        {
            this.Get["/signout"] = p => this.GetKetchup();
        }

        private dynamic GetKetchup()
        {
            var manager = this.Context.GetAuthenticationManager();

            manager?.SignOut();

            return new RedirectResponse("/");
        }
    }
}