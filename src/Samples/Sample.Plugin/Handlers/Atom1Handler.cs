﻿using System;
using Kola.Configuration;
using Kola.Model;
using Kola.Processing;

namespace Sample.Plugin.Handlers
{
    public class Atom1Handler : IHandler
    {
        private readonly IAtom1Dependency atom1Dependency;

        public Atom1Handler(IAtom1Dependency atom1Dependency)
        {
            this.atom1Dependency = atom1Dependency;
        }

        public IRenderingResponse HandleRequest(IComponent component, RequestContext context)
        {
            return new RenderingResponse(() => context.ViewHelper.RenderPartial("atom-1", component));
        }
    }
}
