namespace Kola.Domain
{
    public interface IComponentFactory
    {
        Component Create(string type);
    }
}