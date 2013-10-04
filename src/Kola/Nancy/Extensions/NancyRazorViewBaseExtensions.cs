namespace Kola.Nancy.Extensions
{
    using global::Nancy.ViewEngines.Razor;

    internal static class NancyRazorViewBaseExtensions
    {
        public static string UriFor<TEntity>(this NancyRazorViewBase<TEntity> helper, string path)
        {
            var root = "venus";
            return root.TrimEnd('/') + '/' + path.TrimStart('/');
        }
    }
}