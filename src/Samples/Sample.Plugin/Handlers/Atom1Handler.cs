using Kola.Configuration;

namespace Sample.Plugin.Handlers
{
    public class Atom1Handler : Handler
    {
        private readonly IAtom1Dependency atom1Dependency;

        public Atom1Handler(IAtom1Dependency atom1Dependency)
        {
            this.atom1Dependency = atom1Dependency;
        }
    }
}
