namespace Kola.Service
{
    using System.Collections.Generic;

    using Kola.Configuration;

    public interface IPropertySpecificationLibrary
    {
        IEnumerable<PropertyTypeSpecification> FindAll();

        PropertyTypeSpecification Find(string name);
    }
}