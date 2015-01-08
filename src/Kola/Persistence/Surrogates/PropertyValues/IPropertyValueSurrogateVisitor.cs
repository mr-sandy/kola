namespace Kola.Persistence.Surrogates.PropertyValues
{
    public interface IPropertyValueSurrogateVisitor<out T>
    {
        T Visit(FixedPropertyValueSurrogate surrogate);

        T Visit(InheritedPropertyValueSurrogate surrogate);

        T Visit(MultilingualPropertyValueSurrogate surrogate);
    }
}