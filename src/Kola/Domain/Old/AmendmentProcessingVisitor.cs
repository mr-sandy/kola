//namespace Kola.Domain
//{
//    using System.Collections.Generic;
//    using System.Linq;

//    using Kola.Domain.Amendments;
//    using Kola.Extensions;

//    public class AmendmentProcessingVisitor : IAmendmentVisitor
//    {
//        private readonly Template template;
//        private readonly IComponentFactory componentFactory;

//        public AmendmentProcessingVisitor(Template template, IComponentFactory componentFactory)
//        {
//            this.template = template;
//            this.componentFactory = componentFactory;
//        }

//        public void Visit(AddComponentAmendment amendment)
//        {
//            var parent = this.GetComposite(amendment.ComponentPath);

//            parent.AddComponent(this.componentFactory.Create(amendment.ComponentType), amendment.Index);
//        }

//        public void Visit(MoveComponentAmendment amendment)
//        {
//            var component = this.template.FindChild(amendment.ComponentPath);
//            var sourceParent = this.GetComposite(amendment.ComponentPath.TakeAllButLast());
//            var targetParent = this.GetComposite(amendment.ParentComponentPath);

//            sourceParent.RemoveComponentAt(amendment.ComponentPath.Last());
//            targetParent.AddComponent(component, amendment.Index);
//        }

//        public void Visit(DeleteComponentAmendment amendment)
//        {
//            var index = amendment.ComponentPath.Last();
//            var parent = this.GetComposite(amendment.ComponentPath.TakeAllButLast());

//            parent.RemoveComponentAt(index);
//        }

//        private CompositeComponent GetComposite(IEnumerable<int> componentPath)
//        {
//            var parent = this.template.FindChild(componentPath) as CompositeComponent;

//            if (parent == null)
//            {
//                throw new KolaException("Cannot add child: specified component path does not map to composite component");
//            }

//            return parent;
//        }
//    }
//}