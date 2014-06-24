namespace Kola.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Resources;

    internal class TemplateResourceBuilder
    {
        public TemplateResource Build(Template template)
        {
            var vistor = new ResourceBuildingComponentVisitor2();

            var components = new List<ComponentResource>();

            for (var i = 0; i < template.Components.Count(); i++)
            {
                var component = template.Components.ElementAt(i);

               // components.Add(component.Accept(vistor, Enumerable.Empty<int>()));
            }

            return new TemplateResource { Components = components };
        }
    }

    internal class ResourceBuildingComponentVisitor2 : IComponentVisitor2<ComponentResource, IEnumerable<int>>
    {
        public ComponentResource Visit(Atom atom, IEnumerable<int> context)
        {
            return new ComponentResource
                {
                    Name = atom.Name
                };
        }

        public ComponentResource Visit(Container container, IEnumerable<int> context)
        {
            return new ComponentResource
            {
                Name = container.Name,
                Components = this.BuildChildResources(container, context)
            };
        }

        public ComponentResource Visit(Widget widget, IEnumerable<int> context)
        {
            return new ComponentResource
            {
                Name = widget.Name,
            };
        }

        public ComponentResource Visit(Placeholder placeholder, IEnumerable<int> context)
        {
            return new ComponentResource
            {
                Name = "placeholder"
            };
        }

        private IEnumerable<ComponentResource> BuildChildResources(IComponentCollection componentCollection, IEnumerable<int> context)
        {
            var components = new List<ComponentResource>();

            for (var i = 0; i < componentCollection.Components.Count(); i++)
            {
                var component = componentCollection.Components.ElementAt(i);

                //components.Add(component.Accept(this, context.Append(i)));
            }

            return components;
        }
    }

    public interface IComponentVisitor2<out TResult, in TContext>
    {
        TResult Visit(Atom atom, TContext context);

        TResult Visit(Container container, TContext context);

        TResult Visit(Widget widget, TContext context);

        TResult Visit(Placeholder placeholder, TContext context);
    }
}