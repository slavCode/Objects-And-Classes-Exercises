using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MentorGroup
{
    class Student
    {
        public string Name { get; set; }
        public List<string> Comments { get; set; }
        public List<DateTime> Dates { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string firstInput = Console.ReadLine();
            while (firstInput != "end of dates")
            {
                string[] datesAsString = firstInput.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = datesAsString[0];

                var currentStudent = new Student() { Name = name };
                var dates = new List<DateTime>();
                for (int i = 1; i < datesAsString.Length; i++)
                {
                    string date = datesAsString[i];
                    dates.Add(DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                }

                bool exists = false;
                foreach (var student in students.Where(s => s.Name.Equals(name)))
                {
                    student.Dates.AddRange(dates);
                    exists = true;
                }
                if (!exists)
                {
                    currentStudent.Dates = dates;
                    students.Add(currentStudent);
                }

                firstInput = Console.ReadLine();
            }

            string secondInput = Console.ReadLine();
            while (secondInput != "end of comments")
            {
                string name = secondInput.Split('-')[0];
                string comment = secondInput.Split('-')[1];

                foreach (var student in students)
                {
                    if (student.Name == name)
                    {
                        if (student.Comments == null)
                        {
                            List<string> comments = new List<string>() { comment };
                            student.Comments = comments;
                        }
                        else student.Comments.Add(comment);
                    }
                }

                secondInput = Console.ReadLine();
            }

            foreach (var student in students.OrderBy(s => s.Name))
            {
                Console.WriteLine(student.Name);
                Console.WriteLine("Comments:");
                if (student.Comments != null)
                {
                    foreach (var comment in student.Comments)
                    {
                        Console.WriteLine($"- {comment}");
                    }
                }
                Console.WriteLine("Dates attended:");
                foreach (var date in student.Dates.OrderBy(d => d.Date))
                {
                    Console.WriteLine($"-- {date:dd/MM/yyyy}");
                }
            }
        }
    }
}

