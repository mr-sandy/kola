namespace Kola.Persistence.Surrogates.Conditions
{
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "hasClaim")]
    public class HasClaimConditionSurrogate : ConditionSurrogate
    {
        [XmlAttribute("claim")]
        public string Claim { get; set; }

        public override T Accept<T>(IConditionSurrogateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}