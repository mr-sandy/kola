namespace Kola.Service.ResourceBuilding
{
    public interface IResourceBuilder<in T>
    {
        object Build(T model);
    }
}