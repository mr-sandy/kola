namespace Kola.Domain.Rendering
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;
    
    public interface IRenderer<in T>
    {
        IResult Render(T component);
    }
    
    public interface IRenderer : 
        IRenderer<PageInstance>, 
        IRenderer<IEnumerable<IComponentInstance>>, 
        IRenderer<AtomInstance>, 
        IRenderer<ContainerInstance>, 
        IRenderer<WidgetInstance>, 
        IRenderer<PlaceholderInstance>
    {
    }
}