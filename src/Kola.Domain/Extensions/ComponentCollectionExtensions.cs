namespace Kola.Domain.Extensions
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;

    public static class ComponentCollectionExtensions
    {
        public static IComponentCollection FindCollection(this IComponentCollection componentCollection, IEnumerable<int> path)
        {
            return new CollectionFindingComponentVisitor().Find(componentCollection, path);
        }

        public static IComponent FindComponent(this IComponentCollection componentCollection, IEnumerable<int> path)
        {
            return new ComponentFindingComponentVisitor().Find(componentCollection, path);
        }

        public static IComponentWithProperties FindComponentWithProperties(this IComponentCollection componentCollection, IEnumerable<int> path)
        {
            var candidate = new ComponentFindingComponentVisitor().Find(componentCollection, path);

            if (!(candidate is IComponentWithProperties))
            {
                throw new KolaException("Component with properties not found");
            }

            return candidate as IComponentWithProperties;
        }

        public static IEnumerable<T> FindAll<T>(this IComponentCollection componentCollection) where T : class
        {
            var collectionAsType = componentCollection as T;
            if (collectionAsType != null)
            {
                yield return collectionAsType;
            }

            foreach (var component in componentCollection.Components)
            {
                var componentAsType = component as T;
                if (componentAsType != null)
                {
                    yield return componentAsType;
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