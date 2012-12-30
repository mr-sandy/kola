using System;

namespace Kola.Processing
{
    public class RenderingResponse : IRenderingResponse
    {
        private readonly Func<IViewHelper, string> htmlCommand;

        public RenderingResponse(Func<IViewHelper, string> htmlCommand)
        {
            this.htmlCommand = htmlCommand;
        }

        public string ToHtml(IViewHelper viewHelper)
        {
            return this.htmlCommand(viewHelper);
        }
    }
}