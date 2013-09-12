namespace Kola.Nancy.Modules
{
    using Kola.Domain;

    using IComponent = Kola.Domain.Component;

    public class ComponentFactory : IComponentFactory
    {
        public IComponent Create(string type)
        {
            return new Component(type);
        }
    }
}