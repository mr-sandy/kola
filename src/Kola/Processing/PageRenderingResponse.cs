using System;
using System.Collections.Generic;
using System.Text;

namespace Kola.Processing
{
    public class PageRenderingResponse : IRenderingResponse
    {
         private readonly IEnumerable<IRenderingResponse> renderingResponses;

        public PageRenderingResponse(IEnumerable<IRenderingResponse> renderingResponses)
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
    }
}