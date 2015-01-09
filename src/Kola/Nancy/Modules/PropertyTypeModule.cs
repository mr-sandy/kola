//namespace Kola.Nancy.Modules
//{
//    using Kola.Domain.Composition;
//    using Kola.ResourceBuilding;

//    using global::Nancy;

//    public class PropertyTypeModule : NancyModule
//    {
//        private readonly IPropertySpecificationLibrary propertiespecificationLibrary;

//        public PropertyTypeModule(IPropertySpecificationLibrary propertiespecificationLibrary)
//        {
//            this.propertiespecificationLibrary = propertiespecificationLibrary;
//            this.Get["/_kola/property-types", AcceptHeaderFilters.NotHtml] = p => this.GetPropertyTypes();
//            this.Get["/_kola/property-types/{name}", AcceptHeaderFilters.NotHtml] = p => this.GetPropertyType(p.name);
//        }

//        private dynamic GetPropertyTypes()
//        {
//            var propertySpecifications = this.propertiespecificationLibrary.FindAll();

//            var resource = new PropertyTypeResourceBuilder().Build(propertySpecifications);

//            return this.Negotiate
//                .WithModel(resource)
//                .WithAllowedMediaRange("application/json");
//        }

//        private dynamic GetPropertyType(string name)
//        {
//            var propertiespecification = this.propertiespecificationLibrary.Find(name);

//            var resource = new PropertyTypeResourceBuilder().Build(propertiespecification);

//            return this.Negotiate
//                .WithModel(resource)
//                .WithAllowedMediaRange("application/json");
//        }
//    }
//}