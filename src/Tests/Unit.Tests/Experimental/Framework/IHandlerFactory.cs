namespace Unit.Tests.Experimental.Framework
{
    public interface IHandlerFactory
    {
        IHandler Create(string name);
    }
}