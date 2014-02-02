namespace Unit.Tests.Temp.Domain.Templates
{
    using System;
    using System.Collections.Generic;

    public class Area : IContainer
    {
        public IEnumerable<IComponent> Children
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
