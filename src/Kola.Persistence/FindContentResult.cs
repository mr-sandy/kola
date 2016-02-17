namespace Kola.Persistence
{
    using Kola.Domain.Composition;
    using Kola.Domain.Instances.Config;

    public class FindContentResult
    {
        public FindContentResult(IContent content, IConfiguration configuration)
        {
            this.Content = content;
            this.Configuration = configuration ?? new Configuration();
        }

        public IContent Content { get; }

        public IConfiguration Configuration { get; }
    }
}