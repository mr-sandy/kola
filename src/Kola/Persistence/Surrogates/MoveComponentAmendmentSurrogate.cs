namespace Kola.Persistence.Surrogates
{
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "moveComponent")]
    public class MoveComponentAmendmentSurrogate : AmendmentSurrogate
    {
        [XmlElement("sourcePath")]
        public string SourcePath { get; set; }

        [XmlElement("targetPath")]
        public string TargetPath { get; set; }

        public override void Accept(IAmendmentSurrogateVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}