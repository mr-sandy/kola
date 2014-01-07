namespace Kola.Editing
{
    public interface IComponentVisitor
    {
        void Visit(CompositeComponent component);

        void Visit(SimpleComponent component);
    }
}