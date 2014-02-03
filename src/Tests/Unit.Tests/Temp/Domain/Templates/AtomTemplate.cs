namespace Unit.Tests.Temp.Domain.Templates
{
    using Unit.Tests.Temp.Domain.Instances;

    public class AtomTemplate : IComponent
    {
        public IInstance Build(IBuildContext buildContext)
        {
            return new AtomInstance();
        }
    }
}