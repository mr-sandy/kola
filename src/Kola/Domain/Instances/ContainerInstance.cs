namespace Kola.Domain.Instances
{
    using System.Collections.Generic;

    using Kola.Rendering;

    public class ContainerInstance : IComponentInstance
    {
        public ContainerInstance(string name, IEnumerable<ParameterInstance> parameters, IEnumerable<IComponentInstance> children = null)
        {
            this.Name = name;
            this.Parameters = parameters;
            this.Children = children;
        }

        public string Name { get; private set; }

        public IEnumerable<ParameterInstance> Parameters { get; private set; }

        public IEnumerable<IComponentInstance> Children { get; private set; }

        public IResult Render(IHandlerFactory handlerFactory)
        {
            return handlerFactory.GetHandler(this.Name).Render(this);
        }
    }
}