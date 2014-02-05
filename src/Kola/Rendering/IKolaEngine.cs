namespace Kola.Rendering
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;

    public interface IKolaEngine
    {
        IResult Render(PageInstance page);

        IResult Render(IEnumerable<IComponentInstance> components);
    }
}