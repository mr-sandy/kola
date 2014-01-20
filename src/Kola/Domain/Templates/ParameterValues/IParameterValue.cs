namespace Kola.Domain.Templates.ParameterValues
{
    using System.Collections.Generic;

    public interface IParameterValue
    {
        string Resolve(IEnumerable<Context> contexts);
    }
}