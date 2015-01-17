namespace Kola.Resources
{
    public class RemoveComponentAmendmentResource : AmendmentResource
    {
        public string ComponentPath { get; set; }

        public override string Type
        {
            get { return "Remove Component"; }
        }
        
        public override T Accept<T>(IAmendmentResourceVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}