namespace Kola.Persistence.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Persistence.Surrogates;

    public static class ComponentExtensions
    {
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
                surrogate.Areas != null ? surrogate.Areas.Select(a => a.ToDomain()) : Enumerable.Empty<Area>(),
                surrogate.Parameters != null ? surrogate.Parameters.ToDomain() : Enumerable.Empty<Parameter>());
        }

        public static Placeholder ToDomain(this PlaceholderSurrogate surrogate)
        {
            return new Placeholder();
        }

        public static Area ToDomain(this AreaSurrogate surrogate)
        {
            return new Area(surrogate.Components.ToDomain());
        }
    }
}