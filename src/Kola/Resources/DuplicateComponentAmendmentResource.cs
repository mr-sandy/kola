namespace Kola.Resources
{
    public class DuplicateComponentAmendmentResource : AmendmentResource
    {
        public string ComponentPath { get; set; }

        public override string Type
        {
            get { return "Duplicate Component"; }
        }

        public override T Accept<T>(IAmendmentResourceVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}