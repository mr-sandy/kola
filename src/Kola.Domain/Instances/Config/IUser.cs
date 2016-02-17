namespace Kola.Domain.Instances.Config
{
    using System.Collections.Generic;

    public interface IUser
    {
        IEnumerable<string> Claims { get; }
    }
}