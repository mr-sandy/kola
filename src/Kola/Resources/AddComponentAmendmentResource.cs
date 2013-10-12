namespace Kola.Resources
{
    public class AddComponentAmendmentResource : AmendmentResource
    {
        public string ComponentType { get; set; }

        public string ComponentPath { get; set; }

        public int Index { get; set; }
    }
}