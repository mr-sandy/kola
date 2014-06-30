namespace Kola.Domain.Instances
{
    using Kola.Domain.Rendering;

    public class PlaceholderInstance : IComponentInstance
    {
        public PlaceholderInstance(AreaInstance content)
        {
            this.Content = content;
        }

        public AreaInstance Content { get; private set; }

        public IResult Render(IRenderer renderer)
        {
            return renderer.Render(this.Content);
        }
    }
}