namespace Sample.Plugin.Handlers
{
    using System;

    using Kola.Rendering;

    public class Atom1Handler : IHandler
    {
        private readonly IAtom1Dependency atom1Dependency;

        public Atom1Handler(IAtom1Dependency atom1Dependency)
        {
            this.atom1Dependency = atom1Dependency;
        }

        public IResult HandleRequest(IComponent component)
        {
            return new Result(viewHelper => viewHelper.RenderPartial("atom-1", component));
        }
    }
}
