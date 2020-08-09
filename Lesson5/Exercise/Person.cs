using System;

namespace Lesson5.Exercise
{
    /// <summary>
    /// The Person model
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Init the person
        /// </summary>
        /// <param name="name">The person name</param>
        /// <param name="surname">The person surname</param>
        /// <param name="age"></param>
        public Person(string name, string surname, int age)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
        }

        /// <summary>
        /// The person name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The person surname
        /// </summary>
        public string Surname { get; private set; }

        public int Age { get; private set; }
    }
}
