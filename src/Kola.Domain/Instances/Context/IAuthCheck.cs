namespace Kola.Domain.Instances.Context
{
    public interface IAuthCheck
    {
        bool Test(IUser user);
    }
}