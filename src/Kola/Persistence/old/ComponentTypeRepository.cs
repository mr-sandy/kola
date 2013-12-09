namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Domain;

    public class ComponentTypeRepository : IComponentTypeRepository
    {
        public IEnumerable<ComponentType> FindAll()
        {
            return new[]
                {
                    new ComponentType("Component Type 1"), 
                    new ComponentType("Component Type 2"),
                    new ComponentType("Component Type 3")
                };
        }
    }
}