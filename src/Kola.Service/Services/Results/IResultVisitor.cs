namespace Kola.Service.Services.Results
{
    public interface IResultVisitor<T, out TV>
    {
        TV Visit(SuccessResult<T> result);

        TV Visit(UnauthorisedResult<T> result);

        TV Visit(NotFoundResult<T> result);

        TV Visit(CreatedResult<T> result);

        TV Visit(FailureResult<T> result);

        TV Visit(ConflictResult<T> result);

        TV Visit(MovedPermanentlyResult<T> result);

        TV Visit(ForbiddenResult<T> result);
    }
}