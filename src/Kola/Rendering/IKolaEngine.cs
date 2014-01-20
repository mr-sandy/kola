namespace Kola.Rendering
{
    using System.Collections.Generic;

    using Kola.Domain.Instances;

    public interface IKolaEngine
    {
        IResult Render(IEnumerable<IComponentInstance> children);

        IResult Render(IPage page);
    }
}