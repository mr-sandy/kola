﻿namespace Kola.Processing
{
    using System;

    public interface IObjectFactory
    {
        T Resolve<T>(Type type);
    }
}