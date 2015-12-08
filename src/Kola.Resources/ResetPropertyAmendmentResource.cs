namespace Kola.Resources
{
    public class ResetPropertyAmendmentResource : AmendmentResource
    {
        public string ComponentPath { get; set; }

        public string PropertyName { get; set; }

        public override string Type => "Reset Property";

        public override T Accept<T>(IAmendmentResourceVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}