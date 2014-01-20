namespace Kola.Domain.Templates.Amendments
{
    using System.Collections.Generic;

    public interface IAmendment
    {
        IEnumerable<int> GetRootComponent(); 
        
        void Accept(IAmendmentVisitor visitor);
    }
}