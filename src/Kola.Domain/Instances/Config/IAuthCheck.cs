namespace Kola.Domain.Instances.Config
{
    public interface IAuthCheck
    {
        bool Test(IUser user);
    }
}