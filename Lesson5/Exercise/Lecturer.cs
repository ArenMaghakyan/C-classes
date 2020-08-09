namespace Lesson5.Exercise
{
    /// <summary>
    /// The Lecturer model
    /// </summary>
    public class Lecturer : Person
    {
        /// <summary>
        /// Init the lecturer
        /// </summary>
        /// <param name="name">The lecturer name</param>
        /// <param name="surname">The lecturer surname</param>
        /// <param name="age"></param>
        public Lecturer(string name, string surname, int age) 
            : base(name, surname, age)
        {

        }
    }
}
