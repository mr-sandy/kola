namespace Kola.Nancy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::Nancy.ViewEngines;

    public class CachingResourceViewLocationProvider : IViewLocationProvider
    {
        private readonly ResourceViewLocationProvider inner;
        private readonly Dictionary<string, IEnumerable<ViewLocationResult>> cache = new Dictionary<string, IEnumerable<ViewLocationResult>>();
        private static readonly object LockObject = new Object();

        public CachingResourceViewLocationProvider(ResourceViewLocationProvider inner)
        {
            this.inner = inner;
        }

        public IEnumerable<ViewLocationResult> GetLocatedViews(IEnumerable<string> supportedViewExtensions)
        {
            return this.inner.GetLocatedViews(supportedViewExtensions);
        }

        public IEnumerable<ViewLocationResult> GetLocatedViews(IEnumerable<string> supportedViewExtensions, string location, string viewName)
        {
            var key = string.Format("{0}+{1}", location, viewName);

            if (!this.cache.ContainsKey(key))
            {
                lock (LockObject)
                {
                    if (!this.cache.ContainsKey(key))
                    {
                        this.cache.Add(key, this.inner.GetLocatedViews(supportedViewExtensions, location, viewName).ToArray());
                    }
                }
            }

            return this.cache[key];
        }
    }
}