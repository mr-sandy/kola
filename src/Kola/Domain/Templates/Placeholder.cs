namespace Kola.Domain.Templates
{
    using System;

    using Kola.Domain.Instances;

    public class Placeholder : IComponent
    {
        public void Accept(IComponentVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public IComponentInstance Build(BuildContext buildContext)
        {
            throw new NotImplementedException();
        }
    }
}