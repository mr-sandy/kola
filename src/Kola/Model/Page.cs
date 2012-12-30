using System.Collections.Generic;

namespace Kola.Model
{
    public class Page
    {
        public IEnumerable<IComponent> Components
        {
            get
            {
                return new[]
                           {
                               new Component {Name = "atom-1"}
                           };
            }
        }
    }
}