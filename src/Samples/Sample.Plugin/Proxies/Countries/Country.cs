namespace Sample.Plugin.Proxies.Countries
{
    using System.Diagnostics.CodeAnalysis;

    public class Country
    {
        public static Country UnitedKingdom { get; } = new Country("United Kingdom", "gb");

        public static Country France { get; } = new Country("France", "fr");

        public static Country Badgerland { get; } = new Country("Badgerland", "ba");

        public Country(string name, string code)
        {
            this.Name = name;
            this.Code = code;
        }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}