namespace Kola.Domain.Composition.PropertyValues
{
    using System;

    public class MultilingualVariant
    {
        public MultilingualVariant(string languageCode, string value = "")
        {
            this.LanguageCode = languageCode;
            this.Value = value;
        }

        public string LanguageCode { get; private set; }

        public string Value { get; set; }

        public MultilingualVariant Clone()
        {
            return new MultilingualVariant(this.LanguageCode, this.Value);
        }
    }
}