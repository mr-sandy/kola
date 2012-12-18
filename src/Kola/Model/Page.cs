using System.Collections.Generic;

namespace Kola.Model
{
    public class Page
    {
        public IEnumerable<Component> Components
        {
            get
            {
                return new[]
                           {
                               new Component()
                           };
            }
        }
    }
}