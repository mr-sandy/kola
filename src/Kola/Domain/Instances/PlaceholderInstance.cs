namespace Kola.Domain.Instances
{
    using System.Collections.Generic;

    using Kola.Domain.Rendering;

    public class PlaceholderInstance : ComponentInstance
    {
        public PlaceholderInstance(IEnumerable<int> path, ComponentInstance content)
            : base(path)
        {
            this.Content = content;
        }

        public ComponentInstance Content { get; private set; }

        public override T Accept<T, TContext>(IComponentInstanceVisitor<T, TContext> visitor, TContext context)
        {
            return visitor.Visit(this, context);
        }

        public override IResult Render(IRenderer renderer)
        {
            return this.Content.Render(renderer);
        }
    }
}