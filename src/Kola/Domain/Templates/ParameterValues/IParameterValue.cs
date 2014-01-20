namespace Kola.Domain.Templates.ParameterValues
{
    public interface IParameterValue
    {
        string Resolve(BuildContext buildContext);

        T Accept<T>(IParameterValueVisitor<T> visitor);
    }
}