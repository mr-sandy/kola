namespace Sample.Host.Temporary
{
    using Kola.Processing;

    public class PageHandler : IPageHandler
    {
        public IPage GetPage(string templatePath)
        {
            return new Page
                {
                    Components =
                        new[]
                            {
                                new Component
                                    {
                                        Name = "container-1",
                                        Children =
                                            new[]
                                                {
                                                    new Component { Name = "atom-1", Children = null },
                                                    new Component
                                                        {
                                                            Name = "container-2",
                                                            Children =
                                                                new[]
                                                                    {
                                                                        new Component { Name = "atom-1", Children = null },
                                                                        new Component { Name = "atom-2", Children = null }
                                                                    }
                                                        }
                                                }
                                    }
                            }
                };
        }
    }
}