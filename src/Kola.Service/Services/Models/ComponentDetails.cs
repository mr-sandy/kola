namespace Kola.Service.Services.Models
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;

    public class ComponentDetails
    {
        public ComponentDetails(AmendableComponentCollection owner, IComponent component, IEnumerable<int> componentPath)
        {
            this.Owner = owner;
            this.Component = component;
            this.ComponentPath = componentPath;
        }

        public AmendableComponentCollection Owner { get; }

        public IComponent Component { get; }

        public IEnumerable<int> ComponentPath { get; }
    }
}