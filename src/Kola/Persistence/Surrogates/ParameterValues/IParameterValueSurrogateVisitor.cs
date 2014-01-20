namespace Kola.Persistence.Surrogates.ParameterValues
{
    public interface IParameterValueSurrogateVisitor<out T>
    {
        T Visit(FixedParameterValueSurrogate surrogate);

        T Visit(InheritedParameterValueSurrogate surrogate);

        T Visit(MultilingualParameterValueSurrogate surrogate);
    }
}