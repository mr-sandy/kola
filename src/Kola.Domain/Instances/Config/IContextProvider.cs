namespace Kola.Domain.Instances.Config
{
    using System.Collections.Generic;

    public interface IContextProvider
    {
        IEnumerable<IContextItem> GetContext(IEnumerable<IContextItem> context);
    }
}