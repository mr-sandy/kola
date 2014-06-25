namespace Kola.Resources
{
    public class MoveComponentAmendmentResource : AmendmentResource
    {
        public string SourcePath { get; set; }

        public string TargetPath { get; set; }

        public override string Type
        {
            get { return "Move Component"; }
        }

        public override T Accept<T>(IAmendmentResourceVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}