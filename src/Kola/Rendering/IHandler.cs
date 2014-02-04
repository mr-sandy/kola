namespace Kola.Rendering
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;

    public interface IHandler
    {
        IResult HandleRequest(IComponentInstance component);
    }

    //public class CompositeHandler : IHandler
    //{
    //    public IResult HandleRequest(IComponentInstance component)
    //    {
    //        var widgetInstace = (WidgetInstance)component;

    //        var results = widgetInstace.Children.Select(c => new Result(h => h.RenderPartial(component.Name, component)));

    //        return new CompositeResult(results);
    //    }
    //}
}