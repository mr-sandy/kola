namespace Kola.Domain.Instances.Context
{
    public interface IContextItem
    {
        string Name { get; }

        string Value { get; }
    }
}