using System.Collections.Generic;
using System.Text;

namespace Kola.Processing
{
    public class CompositeRenderingResponse : IRenderingResponse
    {
        private readonly IEnumerable<IRenderingResponse> renderingResponses;

        public CompositeRenderingResponse(IEnumerable<IRenderingResponse> renderingResponses)
        {
            this.renderingResponses = renderingResponses;
        }

        public string ToHtml()
        {
            var sb = new StringBuilder();

            foreach (var renderingResponse in this.renderingResponses)
            {
                sb.Append(renderingResponse.ToHtml());
            }

            return sb.ToString();
        }
    }
}