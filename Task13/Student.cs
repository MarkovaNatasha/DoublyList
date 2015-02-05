using System;

namespace Task13
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DayBirth { get; set; }
        public int Number { get; set; }
        public int Course { get; set; }

        public Student()
        {
        }

        public Student(string name, string surname, DateTime date, int number, int course)
        {
            Name = name;
            Surname = surname;
            DayBirth = date;
            Number = number;
            Course = course;
        }
    }
}
