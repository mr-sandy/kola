using System;
using System.Collections.Generic;
using Kola.Processing.Dependencies;

namespace Kola.Processing
{
    public class RenderingResponse : IRenderingResponse
    {
        private readonly Func<IViewHelper, string> htmlCommand;

        public RenderingResponse(Func<IViewHelper, string> htmlCommand, IEnumerable<IDependency> dependencies)
        {
            this.Dependencies = dependencies;
            this.htmlCommand = htmlCommand;
        }

        public string ToHtml(IViewHelper viewHelper)
        {
            return this.htmlCommand(viewHelper);
        }

        public IEnumerable<IDependency> Dependencies { get; private set; }
    }
}