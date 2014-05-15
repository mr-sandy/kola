namespace Kola.Domain.Composition.ParameterValues
{
    public interface IParameterValueVisitor<out T>
    {
        T Visit(FixedParameterValue fixedParameterValue);

        T Visit(InheritedParameterValue inheritedParameterValue);

        T Visit(MultilingualParameterValue multilingualParameterValue);
    }
}