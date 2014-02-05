namespace Kola.Domain.Templates.ParameterValues
{
    using Kola.Domain.Instances.Building;

    public class UndefinedParameterValue : IParameterValue
    {
        public string Resolve(IBuildContext buildContext)
        {
            return null;
        }

        public T Accept<T>(IParameterValueVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}