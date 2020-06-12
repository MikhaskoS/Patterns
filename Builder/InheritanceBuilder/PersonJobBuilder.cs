namespace Builder.InheritanceBuilder
{
    public class PersonJobBuilder<T> : PersonInfoBuilder<T> where T : PersonJobBuilder<T>
    {
        public T WorksAsA(string position)
        {
            person.Position = position;
            return (T)this;
        }
    }
}
