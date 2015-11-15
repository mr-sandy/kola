namespace Kola.Service.Services
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Service.Services.Results;

    public interface ITemplateService {

        IResult<Template> CreateTemplate(IEnumerable<string> path);

        IResult<Template> GetTemplate(IEnumerable<string> path);

        IResult<IComponent> GetComponent(IEnumerable<string> templatePath, IEnumerable<int> componentPath);

        IResult<Tuple<Template, IAmendment>> AddAmendment(IEnumerable<string> path, IAmendment amendment);

        IResult<IEnumerable<IAmendment>> GetAmendments(IEnumerable<string> path);

        IResult<Template> ApplyAmendments(IEnumerable<string> path);

        IResult<IEnumerable<IEnumerable<int>>> UndoAmendment(IEnumerable<string> path);
    }
}