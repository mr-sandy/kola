namespace Kola.Nancy.Models
{
    public class TemplateQuery
    {
        private string templatePath;
        private string componentPath;
        private string amendmentType;

        public string TemplatePath
        {
            get
            {
                return this.templatePath ?? string.Empty;
            }
            set
            {
                this.templatePath= value;
            }
        }

        public string ComponentPath
        {
            get
            {
                return this.componentPath ?? string.Empty;
            }
            set
            {
                this.componentPath = value;
            }
        }

        public string AmendmentType
        {
            get
            {
                return this.amendmentType ?? string.Empty;
            }
            set
            {
                this.amendmentType = value;
            }
        }
    }
}