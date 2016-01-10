namespace Kola.Nancy.Models
{
    public class WidgetQuery
    {
        private string widgetName;
        private string componentPath;
        private string amendmentType;

        public string WidgetName
        {
            get
            {
                return this.widgetName ?? string.Empty;
            }
            set
            {
                this.widgetName = value;
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