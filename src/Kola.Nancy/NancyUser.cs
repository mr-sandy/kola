namespace Kola.Nancy
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances.Config;

    using global::Nancy.Security;

    public class NancyUser : IUser
    {
        private readonly IUserIdentity user;

        public static NancyUser Create(IUserIdentity user)
        {
            return user == null ? null : new NancyUser(user);
        }

        private NancyUser(IUserIdentity user)
        {
            this.user = user;
        }

        public string UserName => this.user?.UserName;

        public IEnumerable<string> Claims => this.user?.Claims  ?? Enumerable.Empty<string>();
    }
}