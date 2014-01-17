//namespace Kola.Test.Domain.Test
//{
//    using System;
//    using System.Collections.Generic;

//    using Kola.Domain;

//    public interface IComponentSpecification<out T> where T : Kola.Domain.IComponent
//    {
//        string Name { get; }

//        T Create();
//    }

//    public class Atom : Kola.Domain.IComponent {
//        public string Name { get; set; }

//        public void Accept(IComponentVisitor visitor)
//        {
//            throw new NotImplementedException();
//        }
//    }

//    public class Container : Kola.Domain.IComponent
//    {
//        public string Name { get; set; }

//        public void Accept(IComponentVisitor visitor)
//        {
//            throw new NotImplementedException();
//        }
//    }

//    public class Widget : Kola.Domain.IComponent
//    {
//        public string Name { get; set; }

//        public void Accept(IComponentVisitor visitor)
//        {
//            throw new NotImplementedException();
//        }
//    }

//    public class WidgetSpecification : IComponentSpecification<Widget>
//    {
//        public string Name { get; set; }

//        public Widget Create()
//        {
//            throw new NotImplementedException();
//        }
//    }


//    public abstract class PluginSpecification<T> : IComponentSpecification<T> where T : Kola.Domain.IComponent
//    {
//        public string Name { get; set; }
        
//        string SomeOtherProperty { get; set; }

//        public T Create()
//        {
//            throw new NotImplementedException();
//        }
//    }

//    public class ContainerSpecification : PluginSpecification<Container>
//    {
//        public Container Create()
//        {
//            throw new NotImplementedException();
//        }

//        public string SomeOtherProperty { get; set; }
//    }

//    public class AtomSpecification : PluginSpecification<Atom>
//    {
//        public Atom Create()
//        {
//            throw new NotImplementedException();
//        }

//        public string SomeOtherProperty { get; set; }
//    }

//    public class SpecificationFactory
//    {
//        private List<IComponentSpecification<IComponent>> specifications = new List<IComponentSpecification<IComponent>>();

//        public void Add(IComponentSpecification<IComponent> specification)
//        {

//        }

//        public IEnumerable<IComponentSpecification<IComponent>> Specifications
//        {
//            get
//            {
//                return this.specifications;
//            }
//        }
//    }

//    public class Consumer
//    {
//        public void Main()
//        {
//            var factory = new SpecificationFactory();

//            var humanSpecification = new WidgetSpecification();

//            factory.Add(humanSpecification);

//            var zooMonkeySpecification = new ContainerSpecification();

//            factory.Add(zooMonkeySpecification);
//        }
//    }
//}