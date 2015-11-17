namespace Unit.Tests.Domain.TemplateTests
{
    using Kola.Domain;
    using Kola.Domain.Composition;

    using NUnit.Framework;

    public class WhenCreatingANewTemplate
    {
        private Template template;

        [SetUp]
        public void SetUp()
        {
            var templatePath = new[] { "test", "path" };
            this.template = new Template(templatePath);
        }
    }
}
