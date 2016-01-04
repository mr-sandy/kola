namespace Kola.Persistence
{
    using Kola.Domain.Composition;
    using Kola.Domain.Instances.Context;

    public class FindContentResult
    {
        public FindContentResult(IContent content, IContext context)
        {
            this.Content = content;
            this.Context = context;
        }

        public IContent Content { get; }

        public IContext Context { get; }
    }

}