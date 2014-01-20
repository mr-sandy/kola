namespace Kola.Persistence.Surrogates.ParameterValues
{
    public abstract class ParameterValueSurrogate
    {
        public abstract T Accept<T>(IParameterValueSurrogateVisitor<T> visitor);
    }
}