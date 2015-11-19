namespace Kola.Service.Services
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;
    using Kola.Domain.Specifications;
    using Kola.Service.Services.Results;

    public class ComponentSpecificationService : IComponentSpecificationService
    {
        private readonly IComponentSpecificationLibrary componentLibrary;

        public ComponentSpecificationService(IComponentSpecificationLibrary componentLibrary)
        {
            this.componentLibrary = componentLibrary;
        }

        public IResult<IEnumerable<IComponentSpecification<IComponentWithProperties>>> GetComponentSpecifications()
        {
            return new SuccessResult<IEnumerable<IComponentSpecification<IComponentWithProperties>>>(this.componentLibrary.FindAll());
        }
    }
}