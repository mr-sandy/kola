using System;

namespace Kola.Processing
{
    public class RenderingResponse : IRenderingResponse
    {
        private readonly Func<string> htmlCommand;

        public RenderingResponse(Func<string> htmlCommand)
        {
            this.htmlCommand = htmlCommand;
        }

        public string ToHtml()
        {
            return this.htmlCommand();
        }
    }
}