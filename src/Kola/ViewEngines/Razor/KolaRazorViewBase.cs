using System;
using System.Collections.Generic;
using System.Text;

namespace Kola.ViewEngines.Razor
{
    public class KolaRazorViewBase<TModel>
    {
        public TModel Model
        {
            get { throw new NotImplementedException(); }
        }
    }
}
