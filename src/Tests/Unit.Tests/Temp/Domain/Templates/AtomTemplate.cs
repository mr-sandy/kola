namespace Unit.Tests.Temp.Domain.Templates
{
    using Unit.Tests.Temp.Domain.Instances;

    public class AtomTemplate : ITemplate
    {
        public IInstance Build(IBuildContext buildContext)
        {
            return new AtomInstance();
        }
    }
}