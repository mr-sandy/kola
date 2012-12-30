using System.Collections.Generic;

namespace Kola.Processing
{
    public class RenderPageReponse
    {
        public RenderPageReponse(IEnumerable<RenderComponentReponse> renderComponentReponses)
        {
            
        }

        public string Html { get; set; }
    }
}