using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson5.Exercise
{
    /// <summary>
    /// LINQ Exercise model
    /// </summary>
    public class LINQExercise
    {
        /// <summary>
        /// Run LINQ Exercise
        /// </summary>
        public void Run()
        {
            // init temp data
            var disciplines = this.InitDisciplines();

            // Find the count of all students
            var allStudentsCount = disciplines.Select(discipline => discipline.GetStudents()).Sum(st => st.Count());

            // Find the names of students for a discipline which has the maximum number of students
            // option 1
            var maxStudentCount = disciplines.Max(discipline => discipline.GetStudents().Count());
            var biggestDisciplineOp1 = disciplines.Where(discipline => discipline.GetStudents().Count() == maxStudentCount).FirstOrDefault();

            // option 2
            var biggestDisciplineOp2 = disciplines.OrderByDescending(o => o.GetStudents().Count()).FirstOrDefault();

            // Find the name of the discipline with the lesson which has the earliest start date
            var earliestDate = disciplines.SelectMany(discipline => discipline.GetLessons()).Min(m => m.StartDate);

            var earliestLessons = disciplines.SelectMany(discipline => discipline.GetLessons()
                .Where(w => w.StartDate == earliestDate));

            var earliestDiscipline = disciplines.Where(discipline => discipline.GetLessons().Any(a => earliestLessons.Contains(a)));

            // Find the name of the student who participates in the maximum number of disciplines
            var mostActiveStudent = disciplines.SelectMany(discipline => discipline.GetStudents()).GroupBy(g => new { g.Name, g.Surname })
                .OrderByDescending(o => o.Count()).Select(s => s.Key).FirstOrDefault();

            // Find the names of disciplines sorted by the number of students assigned to the discipline
            var sortedDiscipline = disciplines.OrderByDescending(discipline => discipline.GetStudents().Count());



            // HomeWork

            //2.The names of students for a specific discipline.

            var specificName = "English";
            var discipline = disciplines.Find(d=> d.Name == specificName);
            if (discipline != null)
            {
               var studentList =  discipline.GetStudents()
                    .GroupBy(g => new {g.Name, g.Surname})
                    .Select(s => s.Key);
            }


            //4.The lesson with the earliest start date.

            var earliestDate1 = disciplines.SelectMany(discipline => discipline.GetLessons()).Min(m => m.StartDate);

            var earliestLessons1 = disciplines.SelectMany(discipline => discipline.GetLessons()
                .Where(w => w.StartDate == earliestDate1));

                // or if we need just first occurence of earliest lesson

            var earliestLessons2 = disciplines.SelectMany(discipline => discipline.GetLessons()
                .Where(w => w.StartDate == earliestDate1)).FirstOrDefault();


            //6.The names of lecturers which teach the discipline which has the maximum number of students.

            var largestDiscipline = disciplines.OrderByDescending(o => o.GetStudents().Count()).FirstOrDefault();

            if (largestDiscipline != null)
            {
                var lecturers = largestDiscipline.GetLecturers();
            }

            //8.The pairs of student name and discipline name(students are assigned to discipline).

                // Not succeeded

            //10.The names of all students which age is less than 30.

            var youngerStudents = disciplines.SelectMany(d => d.GetStudents())
                .Where(s => s.Age < 30)
                .GroupBy(g => new {g.Name, g.Surname})
                .Select(s => s.Key);

        }

        /// <summary>
        /// Create disciplines
        /// </summary>
        /// <returns></returns>
        private List<Discipline> InitDisciplines()
        {
            // create C# students, lecturers and lessons
            var cSharpStudents = this.InitCSharpStudents();
            var cSharpLecturers = this.InitCSharpLecturers();
            var cSharpLessons = this.InitCSharpLessons();

            // create english students, lecturers and lessons
            var englishStudents = this.InitEnglishStudents();
            var englishLecturers = this.InitEnglishLecturers();
            var englishLessons = this.InitEnglishLessons();

            // create C# discipline
            var cSharpDisciplin = new Discipline("C#");
            cSharpDisciplin.AddStudents(cSharpStudents);
            cSharpDisciplin.AddLecturers(cSharpLecturers);
            cSharpDisciplin.AddLessons(cSharpLessons);

            // create English discipline
            var englishDisciplin = new Discipline("English");
            englishDisciplin.AddStudents(englishStudents);
            englishDisciplin.AddLecturers(englishLecturers);
            englishDisciplin.AddLessons(englishLessons);

            return new List<Discipline> { cSharpDisciplin, englishDisciplin };
        }

        /// <summary>
        /// Create C# students
        /// </summary>
        /// <returns></returns>
        private List<Student> InitCSharpStudents()
        {
            return new List<Student>
            {
                new Student("John", "Smith", 15),
                new Student("Ann", "Jones", 34),
                new Student("Mary", "Wilson", 24),
                new Student("William", "Jackson", 29),
             
            };
        }

        /// <summary>
        /// Create C# lecturers
        /// </summary>
        /// <returns></returns>
        private List<Lecturer> InitCSharpLecturers()
        {
            return new List<Lecturer>
            {
                new Lecturer("Paul", "Flin", 42),
                new Lecturer("Elise", "Black", 32)
            };
        }

        /// <summary>
        /// Create C# Lessons
        /// </summary>
        /// <returns></returns>
        private List<Lesson> InitCSharpLessons()
        {
            return new List<Lesson>
            {
                new Lesson("C# lecture", new DateTime(2020, 6, 1), new DateTime(2020, 9, 29)),
                new Lesson("C# practice", new DateTime(2020, 7, 2), new DateTime(2020, 10, 3))
            };
        }

        /// <summary>
        /// Create English students
        /// </summary>
        /// <returns></returns>
        private List<Student> InitEnglishStudents()
        {
            return new List<Student>
            {
                new Student("John", "Smith", 12),
                new Student("Ann", "Jones", 24),
                new Student("Alice", "White", 35),
                new Student("William", "Jackson", 37),
                new Student("Robert", "Harris", 18),
                new Student("Sophia", "Turner", 19),
                new Student("Edward", "Wood", 40),
                new Student("Martha", "Hall", 19),
            };
        }

        /// <summary>
        /// Create English lecturers
        /// </summary>
        /// <returns></returns>
        private List<Lecturer> InitEnglishLecturers()
        {
            return new List<Lecturer>
            {
                new Lecturer("Dorothy", "Evans", 39)
            };
        }

        /// <summary>
        /// Create English lessons
        /// </summary>
        /// <returns></returns>
        private List<Lesson> InitEnglishLessons()
        {
            return new List<Lesson>
            {
                new Lesson("English", new DateTime(2020, 6, 1), new DateTime(2020, 9, 29))
            };
        }
    }
}
