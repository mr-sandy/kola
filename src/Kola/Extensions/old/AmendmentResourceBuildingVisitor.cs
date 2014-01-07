namespace Kola.Extensions
{
    using System.Collections.Generic;

    using Kola.Editing;
    using Kola.Editing.Amendments;
    using Kola.Resources;

    internal class AmendmentResourceBuildingVisitor : IAmendmentVisitor
    {
        private readonly List<AmendmentResource> amendmentResources = new List<AmendmentResource>();
        private readonly IEnumerable<string> templatePath;
        private readonly int total;
        private int count;

        public AmendmentResourceBuildingVisitor(IEnumerable<string> templatePath, int total)
        {
            this.templatePath = templatePath;
            this.total = total;
            this.count = 0;
        }

        public IEnumerable<AmendmentResource> AmendmentResources
        {
            get { return this.amendmentResources; }
        }

        public void Visit(AddComponentAmendment amendment)
        {
            this.amendmentResources.Add(amendment.ToResource(this.templatePath, ++this.count, this.count == this.total));
        }

        public void Visit(MoveComponentAmendment amendment)
        {
            this.amendmentResources.Add(amendment.ToResource(this.templatePath, ++this.count, this.count == this.total));
        }

        public void Visit(DeleteComponentAmendment amendment)
        {
            this.amendmentResources.Add(amendment.ToResource(this.templatePath, ++this.count, this.count == this.total));
        }
    }
}