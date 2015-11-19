namespace Kola.Service.Services
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Service.Services.Models;
    using Kola.Service.Services.Results;

    public interface ITemplateService {

        IResult<Template> CreateTemplate(IEnumerable<string> path);

        IResult<Template> GetTemplate(IEnumerable<string> path);

        IResult<ComponentDetails> GetComponent(IEnumerable<string> templatePath, IEnumerable<int> componentPath);

        IResult<AmendmentDetails> AddAmendment(IEnumerable<string> path, IAmendment amendment);

        IResult<AmendmentsDetails> GetAmendments(IEnumerable<string> path);

        IResult<AmendmentsDetails> ApplyAmendments(IEnumerable<string> path);

        IResult<UndoAmendmentDetails> UndoAmendment(IEnumerable<string> path);
    }
}