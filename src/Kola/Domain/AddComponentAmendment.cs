namespace Kola.Domain
{
    public class AddComponentAmendment : Amendment
    {
        public AddComponentAmendment(string componentType, string componentPath, int index)
        {
            this.ComponentType = componentType;
            this.ComponentPath = componentPath;
            this.Index = index;
        }

        public string ComponentType { get; private set; }

        public string ComponentPath { get; private set; }

        public int Index { get; private set; }
    }
}