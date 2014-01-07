namespace Kola.Rendering
{
    using System;

    public interface IObjectFactory
    {
        T Resolve<T>(Type type);
    }
}