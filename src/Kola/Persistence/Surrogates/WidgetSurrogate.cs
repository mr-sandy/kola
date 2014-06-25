namespace Kola.Persistence.Surrogates
{
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "widget")]
    public class WidgetSurrogate : ComponentSurrogate
    {
        [XmlArray("areas")]
        public AreaSurrogate[] Areas { get; set; }

        public override T Accept<T>(IComponentSurrogateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}