namespace Kola.Domain.Rendering
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;

    public interface IRenderer
    {
        IResult Render(AtomInstance atom);

        IResult Render(ContainerInstance container);

        IResult Render(WidgetInstance widget);

        IResult Render(PlaceholderInstance placeholder);

        IResult Render(PageInstance page);

        IResult Render(IEnumerable<IComponentInstance> components);
    }
}