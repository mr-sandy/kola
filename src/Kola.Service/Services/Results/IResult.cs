namespace Kola.Service.Services.Results
{
    /******************************************|
    |                                          |
    | 200 | OK            | SuccessResult      |
    | 201 | Created       | CreatedResult      |
    |                                          |
    | 400 | Bad Request   | FailureResult      |
    | 401 | Unauthorized  | UnauthorisedResult |
    | 403 | Forbidden     | ForbiddenResult?   |
    | 404 | Not Found     | NotFoundResult     |
    | 409 | Conflict      | ConflictResult?    |
    |                                          |
    *******************************************/

    public interface IResult<T>
    {
        TV Accept<TV>(IResultVisitor<T, TV> visitor);
    }
}
