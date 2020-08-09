using System;

namespace Lesson5.Exercise
{
    /// <summary>
    /// The Student model
    /// </summary>
    public class Student : Person
    {
        /// <summary>
        /// Student id
        /// </summary>
        private Guid _id;

        /// <summary>
        /// Init the student
        /// </summary>
        /// <param name="name">The student name</param>
        /// <param name="surname">The student surname</param>
        /// <param name="age"></param>
        public Student(string name, string surname, int age)
            : base(name, surname, age)
        {
            _id = Guid.NewGuid();
        }

        public Guid Id { get { return this._id; } }
    }
}
