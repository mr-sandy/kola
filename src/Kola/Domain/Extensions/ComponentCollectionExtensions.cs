namespace Kola.Domain.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola;
    using Kola.Domain.Composition;

    public static class ComponentCollectionExtensions
    {
        public static IComponent FindComponent(this IComponentCollection collection, IEnumerable<int> path)
        {
            return collection.Find<IComponent>(path);
        }

        public static IComponentCollection FindCollection(this IComponentCollection collection, IEnumerable<int> path)
        {
            return collection.Find<IComponentCollection>(path);
        }

        public static T Find<T>(this IComponentCollection collection, IEnumerable<int> path)
        {
            if (path.Count() == 0 && collection is T)
            {
                return (T)collection;
            }
            
            var index = path.First();

            if (collection.Components.Count() >= index)
            {
                if (path.Count() == 1 && collection.Components.ElementAt(index) is T)
                {
                    return (T)collection.Components.ElementAt(index);
                }

                var childCollection = collection.Components.ElementAt(index) as IComponentCollection;

                if (childCollection != null)
                {
                    return childCollection.Find<T>(path.Skip(1));
                }
            }

            throw new KolaException("No component exists at specified path");
        }

        public static IEnumerable<T> FindAll<T>(this IComponentCollection collection)
        {
            if (collection is T)
            {
                yield return (T)collection;
            }

            foreach (var component in collection.Components)
            {
                if (component is T)
                {
                    yield return (T)component;
                }

                var childCollection = component as IComponentCollection;

                if (childCollection != null)
                {
                    foreach (var result in childCollection.FindAll<T>())
                    {
                        yield return result;
                    }
                }
            }
        }
    }
}