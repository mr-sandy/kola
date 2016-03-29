namespace Sample.Plugin.Proxies.Countries
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
    public interface ICountriesService
    {
        Country GetCountry(string ipAddress);
    }
}
