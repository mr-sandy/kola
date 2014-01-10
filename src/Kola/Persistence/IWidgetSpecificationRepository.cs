namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Domain;

    public interface IWidgetSpecificationRepository
    {
        WidgetSpecification Find(string name);

        IEnumerable<WidgetSpecification> FindAll();
    }
}