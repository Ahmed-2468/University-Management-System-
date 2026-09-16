using System;
using System.Collections.Generic;

namespace project1_OOP_eraasoft.Net
{

    public class Instructor
    {
        public int InstructorId { get; set; }

        public string Name { get; set; }

        public string Specialization { get; set; }

        public string PrintDetails()
        {
            return $"ID: {InstructorId}\n" +
                   $"Name: {Name}\n" +
                   $"Specialization: {Specialization}";
        }
    }
}

