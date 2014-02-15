namespace Kola.Domain.Composition.ParameterValues
{
    public class MultilingualVariant
    {
        public MultilingualVariant(string languageCode, string value = "")
        {
            this.LanguageCode = languageCode;
            this.Value = value;
        }

        public string LanguageCode { get; private set; }

        public string Value { get; set; }
    }
}