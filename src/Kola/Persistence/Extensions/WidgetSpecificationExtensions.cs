namespace Kola.Persistence.Extensions
{
    using Kola.Domain.Specifications;
    using Kola.Persistence.Surrogates;

    public static class WidgetSpecificationExtensions
    {
        public static WidgetSpecification ToDomain(this WidgetSpecificationSurrogate surrogate, string name)
        {
            return new WidgetSpecification(name, surrogate.Components.ToDomain());
        }
    }
}