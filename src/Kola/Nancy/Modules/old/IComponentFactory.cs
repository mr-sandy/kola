namespace Kola.Nancy.Modules
{
    using Kola.Domain;

    public interface IComponentFactory
    {
        Component Create(string type);
    }
}