namespace Unit.Tests.Experimental.Framework
{
    using System;

    public interface IHandler
    {
        IResult HandleRequest(IComponent component);
    }

    public class DefaultHandler : IHandler
    {
        public IResult HandleRequest(IComponent component)
        {
            return new Result(h => h.RenderPartial(component.Name, component));
        }
    }
}