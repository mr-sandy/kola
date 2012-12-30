using System;
using System.Collections.Generic;

namespace Kola.Processing
{
    public class KolaEngineConfiguration
    {
        public KolaEngineConfiguration(IDictionary<string, Type> handlerMappings, IObjectFactory objectFactory)
        {
            this.HandlerMappings = handlerMappings;
            this.ObjectFactory = objectFactory;
        }

        public IDictionary<string, Type> HandlerMappings { get; private set; }

        public IObjectFactory ObjectFactory { get; private set; }
    }
}