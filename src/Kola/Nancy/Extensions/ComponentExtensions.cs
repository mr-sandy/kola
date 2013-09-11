namespace Kola.Nancy.Extensions
{
    using Kola.Domain;
    using Kola.Resources;

    internal static class ComponentExtensions
    {
        public static ComponentResource ToResource(this IComponent component)
        {
            return new ComponentResource
            {
                Links = new[]
                            {
                                new LinkResource
                                    {
                                        Rel = "self", Href = string.Format("/{0}", string.Join("/", new[] { "0", "1" }))
                                    }
                            }
            };

        }
    }
}