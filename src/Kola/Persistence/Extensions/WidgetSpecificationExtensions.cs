namespace Kola.Persistence.Extensions
{
    using System.Linq;

    using Kola.Domain;
    using Kola.Domain.Specifications;
    using Kola.Persistence.Surrogates;

    public static class WidgetSpecificationExtensions
    {
        public static WidgetSpecificationSurrogate ToSurrogate(this WidgetSpecification widgetSpecification)
        {
            return new WidgetSpecificationSurrogate
                {
                    Components = widgetSpecification.Components.ToSurrogate().ToArray()
                };
        }

        public static WidgetSpecification ToDomain(this WidgetSpecificationSurrogate surrogate, string name)
        {
            return new WidgetSpecification(name, surrogate.Components.ToDomain());
        }
    }
}