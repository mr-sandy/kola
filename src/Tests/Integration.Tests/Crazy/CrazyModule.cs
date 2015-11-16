//namespace Integration.Tests.Crazy
//{
//    using global::Nancy;
//    using global::Nancy.Responses.Negotiation;

//    public class CrazyModule : NancyModule
//    {
//        private readonly ICrazyService crazyService;

//        public CrazyModule(ICrazyService crazyService)
//        {
//            this.crazyService = crazyService;
//            this.Get["/crazy"] = this.GetCrazy;
//        }

//        private Negotiator GetCrazy(dynamic _)
//        {
//            var result = this.crazyService.GetCrazy();

//            var crazy = new CrazyModel("badger!");
//            return this.Negotiate.WithModel(crazy);
//        }
//    }
//}