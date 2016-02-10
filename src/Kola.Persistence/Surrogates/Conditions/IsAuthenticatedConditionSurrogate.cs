namespace Kola.Persistence.Surrogates.Conditions
{
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "isAuthenticated")]
    public class IsAuthenticatedConditionSurrogate : ConditionSurrogate
    {
        public override T Accept<T>(IConditionSurrogateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}