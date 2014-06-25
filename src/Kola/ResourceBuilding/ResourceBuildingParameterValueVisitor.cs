namespace Kola.ResourceBuilding
{
    using System;

    using Kola.Domain.Composition.ParameterValues;
    using Kola.Resources;

    internal class ResourceBuildingParameterValueVisitor : IParameterValueVisitor<ParameterValueResource>
    {
        public ParameterValueResource Visit(FixedParameterValue fixedParameterValue)
        {
            return new FixedParameterValueResource
                {
                    Value = fixedParameterValue.Value
                };
        }

        public ParameterValueResource Visit(InheritedParameterValue inheritedParameterValue)
        {
            throw new NotImplementedException();
        }

        public ParameterValueResource Visit(MultilingualParameterValue multilingualParameterValue)
        {
            throw new NotImplementedException();
        }
    }
}