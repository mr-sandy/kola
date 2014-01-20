namespace Kola.Persistence.Surrogates.ParameterValues
{
    public class MultilingualParameterValueSurrogate : ParameterValueSurrogate
    {
        public override T Accept<T>(IParameterValueSurrogateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}