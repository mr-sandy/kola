namespace Kola.Domain
{
    public class AmendmentProcessingVisitor : IAmendmentVisitor
    {
        private readonly Template template;

        public AmendmentProcessingVisitor(Template template)
        {
            this.template = template;
        }

        public void Visit(AddComponentAmendment amendment)
        {
        }
    }
}