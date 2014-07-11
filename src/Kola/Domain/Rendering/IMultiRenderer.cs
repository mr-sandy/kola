namespace Kola.Domain.Rendering
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;

    public interface IMultiRenderer : 
        IRenderer<PageInstance>, 
        IRenderer<IEnumerable<ComponentInstance>>, 
        IRenderer<AtomInstance>, 
        IRenderer<ContainerInstance>, 
        IRenderer<WidgetInstance>, 
        IRenderer<AreaInstance>
    {
    }
}