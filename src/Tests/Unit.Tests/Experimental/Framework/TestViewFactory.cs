namespace Unit.Tests.Experimental.Framework
{
    using System;
    using System.Collections.Generic;

    internal class TestViewFactory
    {
        private readonly IViewHelper viewHelper;
        private readonly IDictionary<string, Func<IViewHelper, View<T>>> viewMappings;

        public TestViewFactory(IViewHelper viewHelper, IDictionary<string, Func<IViewHelper, View<T>>> viewMappings)
        {
            this.viewHelper = viewHelper;
            this.viewMappings = viewMappings;
        }

        public View<T> this[string viewName]
        {
            get
            {
                if (this.viewMappings.ContainsKey(viewName))
                {
                    return this.viewMappings[viewName](this.viewHelper);
                }

                throw new Exception(string.Format("No view found for viewname {0}", viewName));
            }
        }
    }

}