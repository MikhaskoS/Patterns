namespace Builder.InheritanceBuilder
{
    // решается сложная задача - вернуть тип, который будет в самом низу иерархии!!!
    // (рекурсивный дженерик) Здесь тип рекурсивно пробрасывается в низ иерархии.
    public class PersonInfoBuilder<T> : PersonBuilder where T : PersonInfoBuilder<T>
    {
        public T Called(string name)
        {
            person.Name = name;
            return (T)this;
        }
    }
}
