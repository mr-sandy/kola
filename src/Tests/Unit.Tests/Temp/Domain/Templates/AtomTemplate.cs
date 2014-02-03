namespace Unit.Tests.Temp.Domain.Templates
{
    using Unit.Tests.Temp.Domain.Instances;

    public class AtomTemplate : IComponentTemplate
    {
        public IComponentInstance Build(IBuildContext buildContext)
        {
            return new AtomInstance();
        }
    }
}