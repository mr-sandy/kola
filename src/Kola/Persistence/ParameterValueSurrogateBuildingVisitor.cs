﻿namespace Kola.Persistence
{
    using System;

    using Kola.Domain.Templates.ParameterValues;
    using Kola.Persistence.Surrogates.ParameterValues;

    internal class ParameterValueSurrogateBuildingVisitor : IParameterValueVisitor<ParameterValueSurrogate>
    {
        public ParameterValueSurrogate Visit(FixedParameterValue fixedParameterValue)
        {
            return new FixedParameterValueSurrogate
                {
                    Value = fixedParameterValue.Value
                };
        }

        public ParameterValueSurrogate Visit(InheritedParameterValue inheritedParameterValue)
        {
            return new InheritedParameterValueSurrogate();
        }

        public ParameterValueSurrogate Visit(MultilingualParameterValue multilingualParameterValue)
        {
            throw new NotImplementedException();
        }

        public ParameterValueSurrogate Visit(UndefinedParameterValue undefinedParameterValue)
        {
            return null;
        }
    }
}