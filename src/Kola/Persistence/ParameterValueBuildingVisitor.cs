﻿namespace Kola.Persistence
{
    using System;

    using Kola.Domain.Composition.ParameterValues;
    using Kola.Persistence.Surrogates.ParameterValues;

    internal class ParameterValueBuildingVisitor : IParameterValueSurrogateVisitor<IParameterValue>
    {
        public IParameterValue Visit(FixedParameterValueSurrogate surrogate)
        {
            return new FixedParameterValue(surrogate.Value);
        }

        public IParameterValue Visit(InheritedParameterValueSurrogate surrogate)
        {
            return new InheritedParameterValue(surrogate.Key);
        }

        public IParameterValue Visit(MultilingualParameterValueSurrogate surrogate)
        {
            throw new NotImplementedException();
        }
    }
}