namespace Kola.Experimental
{
    using System.Collections.Generic;

    public interface IKolaComponent
    {
        string Name { get; }

        IEnumerable<IKolaComponent> Children { get; }
    }
}