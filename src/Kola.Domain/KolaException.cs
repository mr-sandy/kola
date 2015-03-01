namespace Kola
{
    using System;

    public class KolaException : Exception
    {
        public KolaException(string message)
            : base(message)
        {
        }
    }
}