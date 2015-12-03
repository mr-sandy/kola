namespace Kola.Resources
{
    public class SetPropertyInheritedAmendmentResource : AmendmentResource
    {
        public string ComponentPath { get; set; }

        public string PropertyName { get; set; }

        public string Key { get; set; }

        public override string Type => "Set Property Inherited";

        public override T Accept<T>(IAmendmentResourceVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}