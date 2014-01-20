namespace Kola.Domain.Templates.ParameterValues
{
    public class UndefinedParameterValue : IParameterValue
    {
        public string Resolve(BuildContext buildContext)
        {
            return null;
        }

        public T Accept<T>(IParameterValueVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}