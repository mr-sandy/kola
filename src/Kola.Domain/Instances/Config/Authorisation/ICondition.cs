namespace Kola.Domain.Instances.Config.Authorisation
{
    public interface ICondition
    {
        bool Test(IUser user);

        T Accept<T>(IConditionVisitor<T> visitor);
    }
}