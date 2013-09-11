namespace Kola.Nancy.Modules
{
    using Kola.Domain;

    using IComponent = Kola.Domain.IComponent;

    public class ComponentFactory : IComponentFactory
    {
        public IComponent Create(string type)
        {
            return new Atom();
        }
    }
}