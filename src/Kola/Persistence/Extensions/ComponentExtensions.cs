﻿namespace Kola.Persistence.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain;
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
            var visitor = new ComponentBuildingVisitor();

            foreach (var surrogate in surrogates)
            {
                surrogate.Accept(visitor);
            }

            return visitor.Components;
        }

        public static Container ToDomain(this CompositeComponentSurrogate surrogate)
        {
            return new Container(surrogate.Name, surrogate.Components.ToDomain());
        }

        public static Atom ToDomain(this SimpleComponentSurrogate surrogate)
        {
            return new Atom(surrogate.Name);
        }

        public static CompositeComponentSurrogate ToSurrogate(this Container component)
        {
            return new CompositeComponentSurrogate
                {
                    Name = component.Name,
                    Components = component.Components.ToSurrogate().ToArray()
                };
        }

        public static SimpleComponentSurrogate ToSurrogate(this Atom component)
        {
            return new SimpleComponentSurrogate { Name = component.Name };
        }
    }
}