namespace Kola.Domain
{
    using System.Collections.Generic;

    public interface IParameterValue
    {
        string Resolve(IEnumerable<Context> contexts);
    }
}