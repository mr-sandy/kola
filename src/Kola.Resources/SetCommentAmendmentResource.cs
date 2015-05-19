namespace Kola.Resources
{
    public class SetCommentAmendmentResource : AmendmentResource
    {
        public string ComponentPath { get; set; }

        public string Comment { get; set; }

        public override string Type
        {
            get { return "Set Comment"; }
        }

        public override T Accept<T>(IAmendmentResourceVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}