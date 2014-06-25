namespace Kola.Resources
{
    public class DeleteComponentAmendmentResource : AmendmentResource
    {
        public string ComponentPath { get; set; }

        public override string Type
        {
            get { return "Delete Component"; }
        }
        
        public override T Accept<T>(IAmendmentResourceVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}