namespace Kola.Nancy.Modules
{
    using Kola.Editing;

    using IComponent = Kola.Editing.Component;

    public class ComponentFactory : IComponentFactory
    {
        public IComponent Create(string type)
        {
            return new CompositeComponent(type);
        }
    }
}