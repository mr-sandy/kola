namespace Kola.Persistence.Surrogates.Amendments
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace = "http://www.kolacms.com/2013/kola", TypeName = "setParameterFixed")]
    public class SetParameterFixedAmendmentSurrogate : AmendmentSurrogate
    {
        [XmlElement("componentPath")]
        public string ComponentPath { get; set; }

        public string ParameterName { get; set; }

        public string FixedValue { get; set; }

        public override T Accept<T>(IAmendmentSurrogateVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}