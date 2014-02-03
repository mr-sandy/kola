namespace Unit.Tests.Temp.Domain.Templates
{
    using Unit.Tests.Temp.Domain.Instances;

    public class ParameterTemplate 
    {
        public ParameterInstance Build(IBuildContext buildContext)
        {
            return new ParameterInstance();
        }
    }
}