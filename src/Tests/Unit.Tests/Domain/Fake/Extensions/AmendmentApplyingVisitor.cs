namespace Unit.Tests.Domain.Fake.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola;

    public static class ContainerExtensions
    {
        public static IComponentCollection FindComponent(this IComponentCollection container, IEnumerable<int> path)
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
            
            return childCollection.FindComponent(path.Skip(1));
        }
    }
}