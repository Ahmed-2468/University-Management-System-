using System;
using System.Collections.Generic;

namespace project1_OOP_eraasoft.Net
{
    public class StudentManager
    {
        public List<Student> Students { get; set; }

        public List<Course> Courses { get; set; }

        public List<Instructor> Instructors { get; set; }

        public StudentManager()
        {
            Students = new List<Student>();
            Courses = new List<Course>();
            Instructors = new List<Instructor>();
        }

        public bool AddStudent(Student student)
        {
            if (student == null)
                return false;

            foreach (Student s in Students)
            {
                if (s.StudentId == student.StudentId)
                {
                    return false;
                }
            }   

            Students.Add(student);
            return true;
        }

        public bool AddCourse(Course course)
        {
            if (course == null)
                return false;

            foreach (Course c in Courses)
            {
                if (c.CourseId == course.CourseId)
                {
                    return false;
                }
            }

            Courses.Add(course);
            return true;
        }

        public bool AddInstructor(Instructor instructor)
        {
            if (instructor == null)
                return false;

            foreach (Instructor i in Instructors)
            {
                if (i.InstructorId == instructor.InstructorId)
                {
                    return false;
                }
            }

            Instructors.Add(instructor);
            return true;
        }

        public Student FindStudent(int studentId)
        {
            foreach (Student student in Students)
            {
                if (student.StudentId == studentId)
                {
                    return student;
                }
            }

            return null;
        }

        public Course FindCourse(int courseId)
        {
            foreach (Course course in Courses)
            {
                if (course.CourseId == courseId)
                {
                    return course;
                }
            }

            return null;
        }

        public Instructor FindInstructor(int instructorId)
        {
            foreach (Instructor instructor in Instructors)
            {
                if (instructor.InstructorId == instructorId)
                {
                    return instructor;
                }
            }

            return null;
        }

        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);

            if (student == null || course == null)
                return false;

            return student.Enroll(course);
        }

        public bool UpdateStudent(
            int studentId,
            string name,
            int age)
        {
            Student student = FindStudent(studentId);

            if (student == null)
                return false;

            student.Name = name;
            student.Age = age;

            return true;
        }

        public bool DeleteStudent(int studentId)
        {
            Student student = FindStudent(studentId);

            if (student == null)
                return false;

            Students.Remove(student);
            return true;
        }

        public List<Student> FindStudentsByName(string name)
        {
            List<Student> result = new List<Student>();

            foreach (Student student in Students)
            {
                if (student.Name.Contains(
                    name,
                    StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(student);
                }
            }

            return result;
        }

        public List<Course> FindCoursesByName(string title)
        {
            List<Course> result = new List<Course>();

            foreach (Course course in Courses)
            {
                if (course.Title.Contains(
                    title,
                    StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(course);
                }
            }

            return result;
        }
        public bool IsStudentEnrolled(
            int studentId,
            int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);

            if (student == null || course == null)
                return false;

            return student.Courses.Contains(course);
        }

        public string GetInstructorNameByCourseName(string title)
        {
            Course course = null;

            foreach (Course c in Courses)
            {
                if (c.Title.Equals(
                    title,
                    StringComparison.OrdinalIgnoreCase))
                {
                    course = c;
                    break;
                }
            }

            if (course == null || course.Instructor == null)
                return "Not found";

            return course.Instructor.Name;
        }
    }
}   

