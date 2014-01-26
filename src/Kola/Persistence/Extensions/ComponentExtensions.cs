namespace Kola.Persistence.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Templates;
    using Kola.Persistence.Surrogates;

    public static class ComponentExtensions
    {
        public static IEnumerable<ComponentSurrogate> ToSurrogate(this IEnumerable<IComponent> components)
        {
            var visitor = new ComponentSurrogateBuildingVisitor();

            foreach (var component in components)
            {
                component.Accept(visitor);
            }

            return visitor.ComponentSurrogates;
        }

        public static IEnumerable<IComponent> ToDomain(this IEnumerable<ComponentSurrogate> surrogates)
        {
            if (surrogates == null)
            {
                return null;
            }

            var visitor = new ComponentBuildingVisitor();

            foreach (var surrogate in surrogates)
            {
                surrogate.Accept(visitor);
            }

            return visitor.Components;
        }

        public static Container ToDomain(this ContainerSurrogate surrogate)
        {
            return new Container(
                surrogate.Name,
                surrogate.Parameters.ToDomain(),
                surrogate.Components.ToDomain());
        }

        public static Atom ToDomain(this AtomSurrogate surrogate)
        {
            return new Atom(
                surrogate.Name,
                surrogate.Parameters.ToDomain());
        }

        public static Widget ToDomain(this WidgetSurrogate surrogate)
        {
            return new Widget(
                surrogate.Name,
                surrogate.Parameters.ToDomain(),
                 Enumerable.Empty<Area>());
        }

        public static ContainerSurrogate ToSurrogate(this Container component)
        {
            return new ContainerSurrogate
                {
                    Name = component.Name,
                    Parameters = component.Parameters.ToSurrogate().ToArray(),
                    Components = component.Components.ToSurrogate().ToArray()
                };
        }

        public static AtomSurrogate ToSurrogate(this Atom component)
        {
            return new AtomSurrogate
                {
                    Name = component.Name,
                    Parameters = component.Parameters.ToSurrogate().ToArray()
                };
        }

        public static WidgetSurrogate ToSurrogate(this Widget component)
        {
            return new WidgetSurrogate { Name = component.Name };
        }
    }
}