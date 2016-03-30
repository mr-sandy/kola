namespace Sample.Plugin.Proxies.Countries
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
    public class CountriesService : ICountriesService
    {
        public Country GetCountry(string ipAddress)
        {
            if (string.IsNullOrWhiteSpace(ipAddress))
            {
                return null;
            }

            var first = ipAddress.Substring(0, 1);

            switch (first)
            {
                case "1":
                    return Country.UnitedKingdom;

                case "2":
                    return Country.France;

                default:
                    return Country.Badgerland;
            }
        }
    }
}