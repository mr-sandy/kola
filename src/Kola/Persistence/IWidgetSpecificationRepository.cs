namespace Kola.Persistence
{
    using System.Collections.Generic;

    using Kola.Domain;
    using Kola.Domain.Specifications;

    public interface IWidgetSpecificationRepository
    {
        WidgetSpecification Find(string name);

        IEnumerable<WidgetSpecification> FindAll();
    }
}