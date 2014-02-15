namespace Kola.Domain.Composition.ParameterValues
{
    using Kola.Domain.Instances.Building;

    public interface IParameterValue
    {
        string Resolve(IBuildContext buildContext);

        T Accept<T>(IParameterValueVisitor<T> visitor);
    }
}