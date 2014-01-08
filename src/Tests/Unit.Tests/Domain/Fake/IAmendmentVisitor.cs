namespace Unit.Tests.Domain.Fake
{
    using Unit.Tests.Domain.Fake.Amendments;

    public interface IAmendmentVisitor
    {
        void Visit(AddComponentAmendment amendment);
    }
}