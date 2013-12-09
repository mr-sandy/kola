using System;
using System.Collections.Generic;
using System.Text;
using Kola.Processing.Dependencies;

namespace Kola.Processing
{
    public class CompositeRenderingResponse : IRenderingResponse
    {
        private readonly IEnumerable<IRenderingResponse> renderingResponses;

        public CompositeRenderingResponse(IEnumerable<IRenderingResponse> renderingResponses)
        {
            this.renderingResponses = renderingResponses;
        }

        public string ToHtml(IViewHelper viewHelper)
        {
            var sb = new StringBuilder();

            foreach (var renderingResponse in this.renderingResponses)
            {
                sb.Append(renderingResponse.ToHtml(viewHelper));
            }

            return sb.ToString();
        }

        public IEnumerable<IDependency> Dependencies
        {
            get { throw new NotImplementedException(); }
        }
    }
}