using Kola.Domain;
using NUnit.Framework;

namespace Unit.Tests.Templates
{
    public class WhenCreatingANewTemplate : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {
            var templatePath = new[] {"test", "path"};
            this.template = new Template(templatePath);
        }
    }
}
