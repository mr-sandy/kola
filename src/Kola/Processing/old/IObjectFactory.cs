namespace Kola.Processing.old
{
    using System;

    public interface IObjectFactory
    {
        T Resolve<T>(Type type);
    }
}