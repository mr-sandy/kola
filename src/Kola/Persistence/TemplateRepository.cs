﻿using System;
using System.Collections.Generic;
using Kola.Domain;

namespace Kola.Persistence
{
    internal class TemplateRepository : ITemplateRepository
    {
        public void Add(Template template)
        {
        }

        public Template Get(IEnumerable<string> path)
        {
            return null;
        }

        public void Update(Template template)
        {
            throw new NotImplementedException();
        }
    }
}