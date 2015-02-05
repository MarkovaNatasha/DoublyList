using System;
using System.Collections.Generic;

namespace Task13
{
    class Program
    {
        static void Main(string[] args)
        {
            var student1 = new Student("Maria", "Petrova", new DateTime(1990,12,4), 123456, 4);
            var student2 = new Student("Oleg", "Ivanov", new DateTime(1989, 3, 4), 234543, 3);
            var student3 = new Student("Ivan", "Stepanov", new DateTime(1994, 5, 11), 456345, 1);
            var student4 = new Student("Sasha", "Korj", new DateTime(1991, 4, 22), 876345, 5);
            var student5 = new Student("Marina", "Uhova", new DateTime(1989, 7, 19), 234523, 2);
            var students = new MyDoublyList<Student> {student1, student2, student3};
            students.AddFirst(student4);
            students.AddAfter(students.FindNode(student1), student5);
            students.AddBefore(students.FindNode(student3), student4);
            students.Remove(student2);
            students.RemoveFirst();
            Print(students);
            Console.WriteLine();
            SerializationList.SaveListXML("students.xml", students);
            Print(SerializationList.LoadListXML("students.xml"));
            Console.ReadKey();
        }

        static void Print(IEnumerable<Student> students)
        {
            if (students == null) throw new ArgumentNullException("students");
            foreach (var student in students)
            {
                Console.WriteLine(student.Name + " " + student.Surname + " " + student.DayBirth + " " + student.Number + " " + student.Course);
            }
        }
    }
}
