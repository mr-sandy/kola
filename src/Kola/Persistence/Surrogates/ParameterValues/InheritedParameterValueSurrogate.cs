namespace Kola.Persistence.Surrogates.ParameterValues
{
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "inherited")]
    public class InheritedParameterValueSurrogate : ParameterValueSurrogate
    {
        [XmlAttribute("key")]
        public string Key { get; set; }

        public override T Accept<T>(IParameterValueSurrogateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
