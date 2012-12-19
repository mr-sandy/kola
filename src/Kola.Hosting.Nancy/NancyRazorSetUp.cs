using System.Collections.Generic;
using Nancy.Bootstrapper;
using Nancy.ViewEngines.Razor;

namespace Kola.Hosting.Nancy
{
    public class NancyRazorSetUp : IApplicationRegistrations
    {
        public IEnumerable<TypeRegistration> TypeRegistrations
        {
            get
            {
                return new[] { new TypeRegistration(typeof(IRazorConfiguration), typeof(KolaRazorConfiguration)) };
            }
        }

        public IEnumerable<CollectionTypeRegistration> CollectionTypeRegistrations
        {
            get { return null; }
        }

        public IEnumerable<InstanceRegistration> InstanceRegistrations
        {
            get { return null; }
        }
    }
}