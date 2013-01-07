using System.Collections.Generic;

namespace Kola.Model
{
    public class Page
    {
        public string Title { get { return "The Page Title"; } }

        public IEnumerable<IComponent> Components
        {
            get
            {
                return new[]
                           {
                               new Component
                                   {
                                       Name = "container-1",
                                       Children = new[]
                                                      {
                                                          new Component {Name = "atom-1"},
                                                          new Component {Name = "atom-2"}
                                                      }
                                   }
                           };
            }
        }
    }
}