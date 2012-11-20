
using System;

namespace Kola.Configuration
{
    internal class AtomConfiguration
    {
        public AtomConfiguration(string atomName)
        {
            this.AtomName = atomName;
        }

        public string AtomName { get; private set; }

        public void SetHandler<T>()
        {
            throw new NotImplementedException();
        }

        public void SetView(string view)
        {
            throw new NotImplementedException();
        }
    }
}
