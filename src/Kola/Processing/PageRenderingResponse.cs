using System;
using System.Collections.Generic;
using Kola.Domain;
using Kola.Processing.Dependencies;

namespace Kola.Processing
{
    public class PageRenderingResponse : IHtmlResponse
    {
        private readonly Page page;
        private readonly IRenderingResponse renderingResponse;

        private const string PageTemplate =
            @"<!DOCTYPE html>
<html>
<head>
  <title>{0}</title>
</head>
<body>
{1}
</body>
</html>";

        public PageRenderingResponse(Page page, IRenderingResponse renderingResponse)
        {
            this.page = page;
            this.renderingResponse = renderingResponse;
        }

        public string ToHtml(IViewHelper viewHelper)
        {
            return string.Format(PageTemplate, page.Title, renderingResponse.ToHtml(viewHelper));
        }
    }
}