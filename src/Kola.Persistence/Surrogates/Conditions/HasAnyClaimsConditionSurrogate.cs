namespace Kola.Persistence.Surrogates.Conditions
{
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "hasAnyClaims")]
    public class HasAnyClaimsConditionSurrogate : ConditionSurrogate
    {
        [XmlArray("claims")]
        [XmlArrayItem("claim")]
        public string[] Claims { get; set; }

        public override T Accept<T>(IConditionSurrogateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}