namespace Kola.Domain.Templates
{
    using System.Collections.Generic;

    public interface IParameterisedComponent : IComponent
    {
        string Name { get; }

        IEnumerable<Parameter> Parameters { get; }
    }
}