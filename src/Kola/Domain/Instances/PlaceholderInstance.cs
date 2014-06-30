namespace Kola.Domain.Instances
{
    using Kola.Domain.Rendering;

    public class PlaceholderInstance : IComponentInstance
    {
        public PlaceholderInstance(IComponentInstance content)
        {
            this.Content = content;
        }

        public IComponentInstance Content { get; private set; }

        public IResult Render(IRenderer renderer)
        {
            return this.Content.Render(renderer);
        }
    }
}