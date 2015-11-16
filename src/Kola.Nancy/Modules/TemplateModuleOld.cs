
//        private dynamic GetAmendments(string rawTemplatePath)
//        {
//            var templatePath = rawTemplatePath.ParsePath();
//            var template = this.contentRepository.Get(templatePath) as Template;

//            if (template == null)
//            {
//                return HttpStatusCode.NotFound;
//            }

//            var resource = new AmendmentResourceBuilder().Build(template.Amendments, template.Path);

//            return this.Negotiate
//                .WithModel(resource)
//                .WithAllowedMediaRange("application/json")
//                .WithHeader("location", $"/{rawTemplatePath}");
//        }

//        private dynamic GetComponent(string rawTemplatePath, string rawComponentPath)
//        {
//            var templatePath = rawTemplatePath.ParsePath();
//            var template = this.contentRepository.Get(templatePath) as Template;

//            if (template == null)
//            {
//                return HttpStatusCode.NotFound;
//            }

//            template.ApplyAmendments(this.componentLibrary);

//            var componentPath = rawComponentPath.ParseComponentPath().ToArray();

//            var component = template.FindComponent(componentPath);

//            // Add all properties for this component type (not just those with values set)
//            component.Accept(new ComponentRefreshingVisitor(this.componentLibrary));

//            var resource = new ComponentResourceBuilder().Build(component, componentPath, template.Path);

//            return this.Negotiate
//                .WithModel(resource)
//                .WithAllowedMediaRange("application/json")
//                .WithHeader("location", $"/{rawTemplatePath}");
//        }


//        private dynamic PutTemplate(string rawTemplatePath)
//        {
//            var templatePath = rawTemplatePath.ParsePath().ToArray();

//            var existingTemplate = this.contentRepository.Get(templatePath) as Template;
//            if (existingTemplate != null)
//            {
//                return HttpStatusCode.Conflict;
//            }

//            var template = new Template(templatePath);

//            this.contentRepository.Add(template);

//            var resource = new TemplateResourceBuilder().Build(template);

//            return this.Negotiate
//                .WithModel(resource)
//                .WithAllowedMediaRange("application/json")
//                .WithStatusCode(HttpStatusCode.Created)
//                .WithHeader("location", $"/{rawTemplatePath}");
//        }

//        private dynamic PostAmendment<T>(string rawTemplatePath)
//            where T : AmendmentResource
//        {
//            var amendment = new AmendmentDomainBuilder().Build(this.Bind<T>());

//            var templatePath = rawTemplatePath.ParsePath();
//            var template = this.contentRepository.Get(templatePath) as Template;

//            if (template == null)
//            {
//                return HttpStatusCode.NotFound;
//            }

//            template.AddAmendment(amendment);

//            this.contentRepository.Update(template);

//            template.ApplyAmendments(this.componentLibrary);

//            var resource = new AmendmentResourceBuilder().Build(amendment, template.Path, template.Amendments.Count() - 1);

//            return this.Negotiate
//                .WithModel(resource)
//                .WithAllowedMediaRange("application/json")
//                .WithStatusCode(HttpStatusCode.Created);
//        }

//        private dynamic PostApplyAmendments(string rawTemplatePath)
//        {
//            var templatePath = rawTemplatePath.ParsePath();
//            var template = this.contentRepository.Get(templatePath) as Template;

//            if (template == null)
//            {
//                return HttpStatusCode.NotFound;
//            }

//            template.ApplyAmendments(this.componentLibrary, reset: true);

//            this.contentRepository.Update(template);

//            return this.Negotiate
//                .WithModel(new { jam = "biscuits" })
//                .WithAllowedMediaRange("application/json")
//                .WithStatusCode(HttpStatusCode.Created);
//        }

//        private dynamic PostUndoAmendment(string rawTemplatePath)
//        {
//            var templatePath = rawTemplatePath.ParsePath();
//            var template = this.contentRepository.Get(templatePath) as Template;

//            if (template == null)
//            {
//                return HttpStatusCode.NotFound;
//            }

//            var amendment = template.UndoAmendment();

//            this.contentRepository.Update(template);

//            var resource = new
//            {
//                Links = amendment.AffectedPaths.Select(affectedPath => new LinkResource { Rel = "affected", Href = string.Join("/", affectedPath) })
//                        .Union(new[] { new LinkResource { Rel = "subject", Href = string.Join("/", amendment.AffectedPaths.First()) } })
//                        .ToArray()
//            };

//            return this.Negotiate
//                .WithModel(resource)
//                .WithAllowedMediaRange("application/json")
//                .WithStatusCode(HttpStatusCode.OK);
//        }
//    }
//}