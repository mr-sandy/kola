namespace Kola.Service.Services
{
    using System;

    using Kola.Domain.Composition;

    public class ContentVisitor<T> : IContentVisitor<T>
    {
        private readonly Func<Template, T> templateFunction;

        private readonly Func<Redirect, T> redirectFunction;

        public ContentVisitor(Func<Template, T> templateFunction, Func<Redirect, T> redirectFunction)
        {
            this.templateFunction = templateFunction;
            this.redirectFunction = redirectFunction;
        }

        public T Visit(Redirect redirect) => this.redirectFunction(redirect);

        public T Visit(Template template) => this.templateFunction(template);
    }
}