namespace Unit.Tests.Temp.Domain
{
    using System.Collections.Generic;

    public interface IContainer<out T>
        where T : IComponent
    {
        IEnumerable<T> Children { get; }
    }

    public interface IComponent
    {

    }

    public interface IPlaceholder : IComponent
    {
        
    }

    public interface IRealComponent : IComponent
    {

    }
}
