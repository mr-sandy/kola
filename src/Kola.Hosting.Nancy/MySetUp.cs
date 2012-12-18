//using System.Collections.Generic;
//using Nancy.Bootstrapper;
//using Nancy.ViewEngines.Razor;

//namespace Kola.Hosting.Nancy
//{
//    public class MySetUp : IApplicationRegistrations
//    {
//        public IEnumerable<TypeRegistration> TypeRegistrations
//        {
//            get
//            {
//                return new[] { new TypeRegistration(typeof(IRazorConfiguration), typeof(MyRazorConfiguration)) };
//            }
//        }

//        public IEnumerable<CollectionTypeRegistration> CollectionTypeRegistrations
//        {
//            get { return null; }
//        }

//        public IEnumerable<InstanceRegistration> InstanceRegistrations
//        {
//            get { return null; }
//        }
//    }
//}