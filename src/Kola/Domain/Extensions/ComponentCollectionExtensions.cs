namespace Kola.Domain.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola;

    using Kola.Domain;

    public static class ComponentCollectionExtensions
    {
        public static IComponent FindComponent(this IComponentCollection container, IEnumerable<int> path)
        {
            if (path.Count() == 0)
            {
                if (container is IComponent)
                {
                    return container as IComponent;
                }

                throw new KolaException("Specified item is not a component");
            }

            var index = path.First();

            if (container.Components.Count() < index)
            {
                throw new KolaException("No component exists at specified path");
            }

            var childCollection = container.Components.ElementAt(index) as IComponentCollection;

            if (childCollection == null)
            {
                throw new KolaException("No component collection exists at specified path");
            }
            
            return childCollection.FindComponent(path.Skip(1));
        }

        public static IComponentCollection FindCollection(this IComponentCollection container, IEnumerable<int> path)
        {
            if (path.Count() == 0)
            {
                return container;
            }

            var index = path.First();

            if (container.Components.Count() < index)
            {
                throw new KolaException("No component exists at specified path");
            }

            var childCollection = container.Components.ElementAt(index) as IComponentCollection;

            if (childCollection == null)
            {
                throw new KolaException("No component collection exists at specified path");
            }

            return childCollection.FindCollection(path.Skip(1));
        }
    }
}