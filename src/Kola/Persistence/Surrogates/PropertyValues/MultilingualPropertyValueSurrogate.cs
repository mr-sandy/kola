namespace Kola.Persistence.Surrogates.PropertyValues
{
    public class MultilingualPropertyValueSurrogate : PropertyValueSurrogate
    {
        public override T Accept<T>(IPropertyValueSurrogateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}