using System;
using System.Collections.Generic;


namespace project1_OOP_eraasoft.Net
{

    public class Course
    {
        public int CourseId { get; set; }

        public string Title { get; set; }

        public Instructor Instructor { get; set; }

        public string PrintDetails()
        {
            string instructorName = Instructor == null
                ? "No instructor"
                : Instructor.Name;

            return $"ID: {CourseId}\n" +
                   $"Title: {Title}\n" +
                   $"Instructor: {instructorName}";
        }
    }
}

