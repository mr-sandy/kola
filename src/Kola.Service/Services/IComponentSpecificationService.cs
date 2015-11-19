namespace Kola.Service.Services
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;
    using Kola.Service.Services.Results;

    public interface IComponentSpecificationService
    {
        IResult<IEnumerable<IComponentSpecification<IComponentWithProperties>>>  GetComponentSpecifications();
    }
}