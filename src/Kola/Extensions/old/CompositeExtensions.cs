namespace Kola.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain;

    internal static class CompositeExtensions
    {
        public static Component FindChild(this CompositeComponent composite, IEnumerable<int> componentPath)
        {
            if (componentPath.Count() == 0)
            {
                return composite;
            }

            var index = componentPath.First();
            var remainder = componentPath.Skip(1);

            if (index >= composite.Components.Count())
            {
                throw new KolaException("Component index outside bounds");
            }

            var component = composite.Components.ElementAt(index);

            if (remainder.Count() == 0)
            {
                return component;
            }

            var childAsComposite = component as CompositeComponent;

            if (childAsComposite == null)
            {
                throw new KolaException("Component path includes non-composite as parent");
            }

            return childAsComposite.FindChild(remainder);
        }
    }
}