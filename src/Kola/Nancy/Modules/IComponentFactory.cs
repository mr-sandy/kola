namespace Kola.Nancy.Modules
{
    using Kola.Domain;

    public interface IComponentFactory
    {
        IComponent Create(string name);
    }
}