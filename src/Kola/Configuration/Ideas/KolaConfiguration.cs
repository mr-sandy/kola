
using System;

namespace Kola.Configuration.Ideas
{
    public static class KolaConfiguration
    {
        public static void BuildConfiguration()
        {
            
        }
    }

    public class KolaBootstrapper
    {
        public KolaThing Build()
        {
            var kolaThing = new KolaThing();

            //Find all the bits of 
            var bits = new IKolaSetup[] {}; //use reflection

            foreach (var bit in bits)
            {
                bit.Visit(kolaThing);
            }

            return kolaThing;
        }
    }

    public class KolaThing
    {
        public void Accept(HostingSetup kolaThing)
        {
        }

        public void Accept(ViewEngineSetup kolaThing)
        {
        }
    }


    public interface IKolaSetup
    {
        void Visit(KolaThing kolaThing);
    }


    public abstract class ViewEngineSetup : IKolaSetup
    {

        public void Visit(KolaThing kolaThing)
        {
            kolaThing.Accept(this);
        }
    }

    public abstract class HostingSetup : IKolaSetup
    {

        public void Visit(KolaThing kolaThing)
        {
            kolaThing.Accept(this);
        }
    }
}
