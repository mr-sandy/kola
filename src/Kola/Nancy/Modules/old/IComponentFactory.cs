namespace Kola.Nancy.Modules
{
    using Kola.Editing;

    public interface IComponentFactory
    {
        Component Create(string type);
    }
}