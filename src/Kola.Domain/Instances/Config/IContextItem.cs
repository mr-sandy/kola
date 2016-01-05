namespace Kola.Domain.Instances.Config
{
    public interface IContextItem
    {
        string Name { get; }

        string Value { get; }
    }
}