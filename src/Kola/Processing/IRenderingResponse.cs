using System.Collections.Generic;
using Kola.Processing.Dependencies;

namespace Kola.Processing
{
    public interface IHtmlResponse
    {
        string ToHtml(IViewHelper viewHelper);
    }

    public interface IRenderingResponse : IHtmlResponse
    {
        IEnumerable<IDependency> Dependencies { get; }
    }
}


/*
 * The interface IRenderingResponse needs to include:
 *  - An function to return the body HTML
 *  - A list of dependencies - javascript, css, meta data...
 *  - A cachability
 *  
 * When composing the IRenderingResponse for multiple components, we should be able to:
 *  - Encapsulate the renderning of the body HTML in a single call to the ToHtml function
 *  - Present an aggregated (and de-duplicated) list of dependencies
 *  - Perform 'arithmetic' on cacheability to determine how the composite may be cached
 *  
 * The implementation of IRenderingResponse that represents a page should convert the dependencies presented
 * by the aggregate into html - either in the header or body (as dictated by their configuration?)
 * 
 * */
