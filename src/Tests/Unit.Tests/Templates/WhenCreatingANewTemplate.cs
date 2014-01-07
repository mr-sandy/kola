namespace Unit.Tests.Templates
{
    using Kola.Editing;

    using NUnit.Framework;

    public class WhenCreatingANewTemplate : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {
            var templatePath = new[] { "test", "path" };
            this.Template = new Template(templatePath);
        }
    }
}
