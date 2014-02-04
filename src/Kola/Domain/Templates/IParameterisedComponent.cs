namespace Kola.Domain.Templates
{
    using System.Collections.Generic;

    public interface IParameterisedComponent : IComponentTemplate
    {
        string Name { get; }

        IEnumerable<ParameterTemplate> Parameters { get; }
    }
}