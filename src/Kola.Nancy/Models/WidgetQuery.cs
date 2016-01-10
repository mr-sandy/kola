namespace Kola.Nancy.Models
{
    public class WidgetQuery
    {
        private string mame;
        private string componentPath;
        private string amendmentType;

        public string Name
        {
            get
            {
                return this.mame ?? string.Empty;
            }
            set
            {
                this.mame = value;
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