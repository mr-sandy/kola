namespace Kola.Rendering
{
    using System;

    using Kola.Domain.Instances;

    public interface IRenderer
    {
        IResult Render(AtomInstance atom);

        IResult Render(ContainerInstance container);

        IResult Render(WidgetInstance widget);

        IResult Render(PlaceholderInstance placeholder);
    }
}