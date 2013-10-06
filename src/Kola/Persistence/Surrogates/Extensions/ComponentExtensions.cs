namespace Kola.Persistence.Surrogates.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain;

    public static class ComponentExtensions
    {
        public static IEnumerable<ComponentSurrogate> ToSurrogate(this IEnumerable<Component> components)
        {
            var visitor = new ComponentSurrogateBuildingVisitor();

            foreach (var component in components)
            {
                component.Accept(visitor);
            }

            return visitor.ComponentSurrogates;
        }

        public static IEnumerable<Component> ToDomain(this IEnumerable<ComponentSurrogate> surrogates)
        {
            var visitor = new ComponentBuildingVisitor();

            foreach (var surrogate in surrogates)
            {
                surrogate.Accept(visitor);
            }

            return visitor.Components;
        }

        public static CompositeComponent ToDomain(this CompositeComponentSurrogate surrogate)
        {
            return new CompositeComponent(surrogate.Name, surrogate.Components.ToDomain());
        }

        public static SimpleComponent ToDomain(this SimpleComponentSurrogate surrogate)
        {
            return new SimpleComponent(surrogate.Name);
        }

        public static CompositeComponentSurrogate ToSurrogate(this CompositeComponent component)
        {
            return new CompositeComponentSurrogate
                {
                    Name = component.Name,
                    Components = component.Components.ToSurrogate().ToArray()
                };
        }

        public static SimpleComponentSurrogate ToSurrogate(this SimpleComponent component)
        {
            return new SimpleComponentSurrogate { Name = component.Name };
        }
    }
}