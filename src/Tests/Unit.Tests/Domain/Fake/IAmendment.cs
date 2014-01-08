namespace Unit.Tests.Domain.Fake
{
    public interface IAmendment
    {
        void Accept(IAmendmentVisitor visitor);
    }
}