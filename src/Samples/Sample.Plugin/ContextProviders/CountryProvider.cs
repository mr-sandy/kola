namespace Sample.Plugin.ContextProviders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances.Config;

    using Sample.Plugin.Proxies.Countries;

    public class CountryProvider : IContextProvider
    {
        private readonly ICountriesService countriesService;

        public CountryProvider(ICountriesService countriesService)
        {
            this.countriesService = countriesService;
        }

        public IEnumerable<IContextItem> GetContext(IEnumerable<IContextItem> context)
        {
            var ipAddress = context.FirstOrDefault(c => c.Name.Equals("ipaddress", StringComparison.InvariantCultureIgnoreCase))?.Value;

            if (!string.IsNullOrEmpty(ipAddress))
            {
                var country = this.countriesService.GetCountry(ipAddress);

                if (country != null)
                {
                    yield return new ContextItem("country", country.Name);
                }
            }
        }
    }
}