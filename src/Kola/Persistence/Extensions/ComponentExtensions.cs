namespace Kola.Persistence.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Templates;
    using Kola.Persistence.Surrogates;

    public static class ComponentExtensions
    {
        public static IEnumerable<ComponentSurrogate> ToSurrogate(this IEnumerable<IComponentTemplate> components)
        {
            var visitor = new ComponentSurrogateBuildingVisitor();

            foreach (var component in components)
            {
                component.Accept(visitor);
            }

            return visitor.ComponentSurrogates;
        }

        public static IEnumerable<IComponentTemplate> ToDomain(this IEnumerable<ComponentSurrogate> surrogates)
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

        public static ContainerTemplate ToDomain(this ContainerSurrogate surrogate)
        {
            return new ContainerTemplate(
                surrogate.Name,
                surrogate.Parameters.ToDomain(),
                surrogate.Components.ToDomain());
        }

        public static AtomTemplate ToDomain(this AtomSurrogate surrogate)
        {
            return new AtomTemplate(
                surrogate.Name,
                surrogate.Parameters.ToDomain());
        }

        public static WidgetTemplate ToDomain(this WidgetSurrogate surrogate)
        {
            return new WidgetTemplate(
                surrogate.Name,
                surrogate.Parameters.ToDomain(),
                 Enumerable.Empty<Area>());
        }

        public static PlaceholderTemplate ToDomain(this PlaceholderSurrogate surrogate)
        {
            return new PlaceholderTemplate();
        }

        public static ContainerSurrogate ToSurrogate(this ContainerTemplate component)
        {
            return new ContainerSurrogate
                {
                    Name = component.Name,
                    Parameters = component.Parameters.ToSurrogate().ToArray(),
                    Components = component.Components.ToSurrogate().ToArray()
                };
        }

        public static AtomSurrogate ToSurrogate(this AtomTemplate component)
        {
            return new AtomSurrogate
                {
                    Name = component.Name,
                    Parameters = component.Parameters.ToSurrogate().ToArray()
                };
        }

        public static WidgetSurrogate ToSurrogate(this WidgetTemplate component)
        {
            return new WidgetSurrogate { Name = component.Name };
        }

        public static PlaceholderSurrogate ToSurrogate(this PlaceholderTemplate component)
        {
            return new PlaceholderSurrogate();
        }
    }
}