namespace Kola.Resources
{
    public class MoveComponentAmendmentResource : AmendmentResource
    {
        public string ParentComponentPath { get; set; }

        public string ComponentPath { get; set; }

        public int Index { get; set; }
    }
}