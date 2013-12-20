namespace Kola.Experimental
{
    public interface IKolaHandler
    {
        IKolaResponse Render(IKolaComponent component, IViewHelper viewHelper);
    }
}