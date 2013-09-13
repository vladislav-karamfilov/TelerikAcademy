namespace BloggingSystem.IntegrationTests
{
    internal class Route
    {
        public Route(string name, string template, object defaults)
        {
            this.Name = name;
            this.Template = template;
            this.Defaults = defaults;
        }

        public object Defaults { get; set; }

        public string Name { get; set; }

        public string Template { get; set; }
    }
}
