namespace Kola.Persistence.SurrogateBuilders
{
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Persistence.Surrogates;

    internal class TemplateSurrogateBuilder
    {
        public TemplateSurrogate Build(Template template)
        {
            var componentBuilder = new SurrogateBuildingComponentVisitor();
            var amendmentBuilder = new SurrogateBuildingAmendmentVisitor();

            return new TemplateSurrogate
                {
                    Components = template.Components.Select(c => c.Accept(componentBuilder)).ToArray(),
                    Amendments = template.Amendments.Select(a => a.Accept(amendmentBuilder)).ToArray()
                };
        }
    }
}
