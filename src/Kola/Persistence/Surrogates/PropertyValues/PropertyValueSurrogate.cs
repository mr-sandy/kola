namespace Kola.Persistence.Surrogates.PropertyValues
{
    public abstract class PropertyValueSurrogate
    {
        public abstract T Accept<T>(IPropertyValueSurrogateVisitor<T> visitor);
    }
}