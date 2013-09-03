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
                    new ComponentType { Name = "Component Type 1" }, 
                    new ComponentType { Name = "Component Type 2" },
                    new ComponentType { Name = "Component Type 3" }
                };
        }
    }
}