namespace Kola.Domain.Instances.Config.Authorisation
{
    public class IsAuthenticatedCondition : ICondition
    {
        public bool Test(IUser user)
        {
            return user != null;
        }

        public T Accept<T>(IConditionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}