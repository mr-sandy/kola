namespace Kola.Domain.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola;
    using Kola.Domain.Composition;

    public static class ComponentCollectionExtensions
    {
        public static IComponentCollection FindCollection(this Template template, IEnumerable<int> path)
        {
            return new CollectionFindingComponentVisitor().Find(template, path);
        }

        public static IComponent FindComponent(this Template template, IEnumerable<int> path)
        {
            return new ComponentFindingComponentVisitor().Find(template, path);
        }

        public static IParameterisedComponent FindParameterisedComponent(this Template template, IEnumerable<int> path)
        {
            var candidate = new ComponentFindingComponentVisitor().Find(template, path);

            if (!(candidate is IParameterisedComponent))
            {
                throw new KolaException("Parameterised component not found");
            }

            return candidate as IParameterisedComponent;
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