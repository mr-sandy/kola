namespace Kola.Domain.Instances.Config
{
    using System.Collections.Generic;

    public interface IUser
    {
        string UserName { get; }

        IEnumerable<string> Claims { get; }
    }
}