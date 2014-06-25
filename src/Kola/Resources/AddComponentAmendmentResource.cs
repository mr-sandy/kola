namespace Kola.Resources
{
    using System;

    public class AddComponentAmendmentResource : AmendmentResource
    {
        public string ComponentType { get; set; }

        public string TargetPath { get; set; }

        public override string Type
        {
            get { return "Add Component"; }
        }

        public override T Accept<T>(IAmendmentResourceVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}