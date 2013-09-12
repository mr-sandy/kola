//namespace Kola.Domain
//{
//    using System.Collections.Generic;

//    public abstract class ComponentContainer : IComponent
//    {
//        private readonly List<IComponent> components = new List<IComponent>();

//        public string Name { get; set; }

//        public IEnumerable<IComponent> Components
//        {
//            get { return this.components; }
//        }

//        public bool AddChild(int index, IComponent component)
//        {
//            this.components.Insert(index, component);

//            return true;
//        }

//        public bool AddComponent(IComponent component, int index = 0)
//        {
//            this.components.Insert(index, component);

//            return true;
//        }
//    }
//}