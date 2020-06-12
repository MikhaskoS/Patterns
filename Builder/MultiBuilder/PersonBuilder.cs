namespace Builder.MultiBuilder
{
    public class PersonBuilder
    {
        protected Person person;

        public PersonBuilder() => person = new Person();
        protected PersonBuilder(Person person) => this.person = person;

        // Суб-бидеры наследуют базовый класс и будут плодить своих Person
        // Следующие действия нужны для того, чтобы это не происходило
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);
        public PersonJobBuilder Works => new PersonJobBuilder(person);

        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person;
        }
    }
}
