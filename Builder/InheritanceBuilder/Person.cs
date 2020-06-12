using System;

namespace Builder.InheritanceBuilder
{
    public class Person
    {
        public string Name;
        public string Position;  // должность
        public DateTime DateOfBirth;

        // Вспомогательный класс в самом низу иерархии (нарушение SOLID)
        public class Builder : PersonBirthDateBuilder<Builder>
        {
            internal Builder() { }
        }
        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }
}
