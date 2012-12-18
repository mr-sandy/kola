using System.Collections.Generic;
using Kola.Hosting.Nancy;
using Nancy.Bootstrapper;
using Nancy.ViewEngines.Razor;

namespace Sample.Host
{
    public class MySetUp : IApplicationRegistrations
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