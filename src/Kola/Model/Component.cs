
namespace Kola.Model
{
    public interface IComponent
    {
        string Name { get; }
    }

    public class Component : IComponent
    {
        public string Name { get; set; }
    }
}
