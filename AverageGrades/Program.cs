using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AverageGrades
{
    internal class Program
    {
        static void Main()
        {
            var studentsCount = int.Parse(Console.ReadLine());
            var students = new List<Student>();

            for (int i = 0; i < studentsCount; i++)
            {
                var input = Console.ReadLine().Split().ToArray();
                var name = input[0];

                var student = new Student();
                student.Name = name;
                var grades = new List<double>();
                grades = ReadGrades(input);
                student.Grades = grades;
                students.Add(student);
            }

            PrintStudents(students);
        }

        static void PrintStudents(List<Student> students)
        {
            foreach (var student in students.Where(s => s.AverageGrades >= 5.00)
                                            .OrderBy(s => s.Name)
                                            .ThenByDescending(s => s.AverageGrades))
            {
                Console.WriteLine($"{student.Name} -> {student.AverageGrades:f2}");
            }
        }

        static List<double> ReadGrades(string[] input)
        {
            var grades = new List<double>();
            for (int k = 1; k < input.Length; k++)
            {
                double grade = double.Parse(input[k], CultureInfo.InvariantCulture);
                grades.Add(grade);
            }
            return grades;
        }
    }
    class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }
        public double AverageGrades
        {
            get
            {
                return Grades.Average();
            }
        }
    }
}
