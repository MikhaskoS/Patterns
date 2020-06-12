using System;

namespace Builder.InheritanceBuilder
{
    public class PersonBirthDateBuilder<T> : PersonJobBuilder<T> 
        where T : PersonBirthDateBuilder<T>
    {
        public T Born(DateTime dateOfBirth)
        {
            person.DateOfBirth = dateOfBirth;
            return (T)this;
        }
    }
}
