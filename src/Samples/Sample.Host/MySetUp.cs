using Kola.Hosting.Nancy;

namespace Sample.Host
{
    /// <summary>
    /// I can't work out why, but it seems like the class causing the registration of KolaRazorConfiguration has to be in the host
    /// So this otherwise redundant class has to remain
    /// </summary>
    public class MySetUp : NancyRazorSetUp
    {
    }
}