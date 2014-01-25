namespace Kola.Domain.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola;

    using Kola.Domain;
    using Kola.Domain.Templates;

    // TODO {SC} Refactor this mess once I've implemented widgets (because a placeholder should be an IComponentCollection but not an IComponent)
    public static class ComponentCollectionExtensions
    {
        public static IComponent FindComponent(this IComponentCollection collection, IEnumerable<int> path)
        {
            return collection.FindComponent<IComponent>(path);
        }

        public static IComponentCollection FindCollection(this IComponentCollection collection, IEnumerable<int> path)
        {
            return collection.FindComponent<IComponentCollection>(path);
        }

        public static T FindComponent<T>(this IComponentCollection collection, IEnumerable<int> path)
        {
            if (path.Count() == 0 && collection is T)
            {
                return (T)collection;
            }
            else
            {
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
                        return childCollection.FindComponent<T>(path.Skip(1));
                    }
                }
            }

            throw new KolaException("No component exists at specified path");
        }

        //public static T FindCollection2<T>(this IComponentCollection container, IEnumerable<int> path)
        //{
        //    if (path.Count() == 0 && container is T)
        //    {
        //        return (T)container;
        //    }
        //    else
        //    {
        //        var index = path.First();

        //        if (container.Components.Count() >= index)
        //        {
        //            if (path.Count() == 1 && container.Components.ElementAt(index) is T)
        //            {
        //                return (T)container.Components.ElementAt(index);
        //            }

        //            var childCollection = container.Components.ElementAt(index) as IComponentCollection;

        //            if (childCollection != null)
        //            {
        //                return childCollection.FindCollection2<T>(path.Skip(1));
        //            }
        //        }
        //    }

        //    throw new KolaException("No component exists at specified path");
        //}


        //public static IComponentCollection FindCollection(this IComponentCollection container, IEnumerable<int> path)
        //{
        //    if (path.Count() == 0)
        //    {
        //        return container;
        //    }

        //    var index = path.First();

        //    if (container.Components.Count() < index)
        //    {
        //        throw new KolaException("No component exists at specified path");
        //    }

        //    var childCollection = container.Components.ElementAt(index) as IComponentCollection;

        //    if (childCollection == null)
        //    {
        //        throw new KolaException("No component collection exists at specified path");
        //    }

        //    return childCollection.FindCollection(path.Skip(1));
        //}

        //public static IComponent FindComponent(this IComponentCollection collection, IEnumerable<int> path)
        //{
        //    if (path.Count() == 0)
        //    {
        //        if (collection is IComponent)
        //        {
        //            return collection as IComponent;
        //        }
        //    }
        //    else
        //    {
        //        var index = path.First();

        //        if (collection.Components.Count() >= index)
        //        {
        //            if (path.Count() == 1)
        //            {
        //                return collection.Components.ElementAt(index);
        //            }

        //            var childCollection = collection.Components.ElementAt(index) as IComponentCollection;

        //            if (childCollection != null)
        //            {
        //                return childCollection.FindComponent(path.Skip(1));
        //            }
        //        }
        //    }

        //    throw new KolaException("No component exists at specified path");
        //}
    }
}