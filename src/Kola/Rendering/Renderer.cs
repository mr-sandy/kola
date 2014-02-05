namespace Kola.Rendering
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances;

    public class Renderer : IRenderer
    {
        private readonly IHandlerFactory handlerFactory;

        public Renderer(IHandlerFactory handlerFactory)
        {
            this.handlerFactory = handlerFactory;
        }

        public IResult Render(AtomInstance atom)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Processing atom {0}", atom.Name));
            return this.handlerFactory.GetAtomHandler(atom.Name).Render(atom);
        }

        public IResult Render(ContainerInstance container)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Processing container {0}", container.Name));
            return this.handlerFactory.GetContainerHandler(container.Name).Render(container);
        }

        public IResult Render(WidgetInstance widget)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Processing widget {0}", widget.Name));
            return new CompositeResult(widget.Components.Select(c => c.Render(this)));
        }

        public IResult Render(PlaceholderInstance placeholder)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Processing placeholder {0}", placeholder.Name));
            return new CompositeResult(placeholder.Components.Select(c => c.Render(this)));
        }

        //public IResult Render(PageInstance page)
        //{
        //    throw new NotImplementedException();
        //}

        //public IResult Render(IEnumerable<IComponentInstance> components)
        //{
        //    throw new NotImplementedException();
        //}
    }
}