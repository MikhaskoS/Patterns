namespace Builder.BuilderBase
{
    public class HtmlBuilder
    {
        private readonly string rootName;  //  удобно для Reset
        protected HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        // not fluent
        public void AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
        }

        // fluent - оч. удобный способ построения через точку
        public HtmlBuilder AddChildFluent(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
            return this; // <- !!!
        }

        public override string ToString() => root.ToString();

        public void Clear()
        {
            root = new HtmlElement { Name = rootName };
        }

        public HtmlElement Build() => root;

        // преобразование HtmlBuilder в HtmlElement (корневой)
        public static implicit operator HtmlElement(HtmlBuilder builder)
        {
            return builder.root;
        }
    }
}
