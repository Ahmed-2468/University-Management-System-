using System;
using System.Collections.Generic;

    
namespace project1_OOP_eraasoft.Net
{

    public class Student
    {
        public int StudentId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public List<Course> Courses { get; set; }

        public Student()
        {
            Courses = new List<Course>();
        }

        public bool Enroll(Course course)
        {
            if (course == null)
                return false;

            if (Courses.Contains(course))
                return false;

            Courses.Add(course);
            return true;
        }

        public string PrintDetails()
        {
            string courses = "No courses";

            if (Courses.Count > 0)
            {
                courses = "";

                foreach (Course course in Courses)
                {
                    courses += course.Title + ", ";
                }

                courses = courses.TrimEnd(',', ' ');
            }

            return $"ID: {StudentId}\n" +
                   $"Name: {Name}\n" +
                   $"Age: {Age}\n" +
                   $"Courses: {courses}";
        }
    }
}   

