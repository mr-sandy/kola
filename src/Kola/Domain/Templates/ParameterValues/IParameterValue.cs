namespace Kola.Domain.Templates.ParameterValues
{
    public interface IParameterValue
    {
        string Resolve(IBuildContext buildContext);

        T Accept<T>(IParameterValueVisitor<T> visitor);
    }
}