namespace Kola.Resources
{
    public class AddComponentAmendmentResource : AmendmentResource
    {
        public string ComponentType { get; set; }

        public string TargetPath { get; set; }

        public override string Type => "Add Component";

        public override T Accept<T>(IAmendmentResourceVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}