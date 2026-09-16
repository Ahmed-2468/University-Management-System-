namespace project1_OOP_eraasoft.Net
{

    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();

            while (true)
            {
                ShowMenu();

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        AddStudent(manager);
                        break;

                    case "2":
                        AddInstructor(manager);
                        break;

                    case "3":
                        AddCourse(manager);
                        break;

                    case "4":
                        EnrollStudent(manager);
                        break;

                    case "5":
                        ShowAllStudents(manager);
                        break;

                    case "6":
                        ShowAllCourses(manager);
                        break;

                    case "7":
                        ShowAllInstructors(manager);
                        break;

                    case "8":
                        FindStudent(manager);
                        break;

                    case "9":
                        FindCourse(manager);
                        break;

                    case "10":
                        return;

                    case "11":
                        CheckEnrollment(manager);
                        break;

                    case "12":
                        GetInstructorByCourse(manager);
                        break;

                    case "13":
                        UpdateStudent(manager);
                        break;

                    case "14":
                        DeleteStudent(manager);
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("================================");
            Console.WriteLine("     STUDENT MANAGEMENT SYSTEM");
            Console.WriteLine("================================");

            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Instructor");
            Console.WriteLine("3. Add Course");
            Console.WriteLine("4. Enroll Student in Course");
            Console.WriteLine("5. Show All Students");
            Console.WriteLine("6. Show All Courses");
            Console.WriteLine("7. Show All Instructors");
            Console.WriteLine("8. Find Student");
            Console.WriteLine("9. Find Course");
            Console.WriteLine("10. Exit");

            Console.WriteLine("\nExtra Requirements:");
            Console.WriteLine("13. Update Student");
            Console.WriteLine("14. Delete Student");

            Console.WriteLine("\nBonus:");
            Console.WriteLine("11. Check Student Enrollment");
            Console.WriteLine("12. Get Instructor name by Course");

         

            Console.WriteLine("================================");
        }

        static void AddStudent(StudentManager manager)
        {
            Console.Write("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Student Age: ");
            int age = int.Parse(Console.ReadLine());

            Student student = new Student
            {
                StudentId = id,
                Name = name,
                Age = age
            };

            if (manager.AddStudent(student))
                Console.WriteLine("Student added successfully.");
            else
                Console.WriteLine("Student ID already exists.");
        }

        static void AddInstructor(StudentManager manager)
        {
            Console.Write("Enter Instructor ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Instructor Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Specialization: ");
            string specialization = Console.ReadLine();

            Instructor instructor = new Instructor
            {
                InstructorId = id,
                Name = name,
                Specialization = specialization
            };

            if (manager.AddInstructor(instructor))
                Console.WriteLine("Instructor added successfully.");
            else
                Console.WriteLine("Instructor ID already exists.");
        }

        static void AddCourse(StudentManager manager)
        {
            Console.Write("Enter Course ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Course Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Instructor ID: ");
            int instructorId = int.Parse(Console.ReadLine());

            Instructor instructor =
                manager.FindInstructor(instructorId);

            if (instructor == null)
            {
                Console.WriteLine("Instructor not found.");
                return;
            }

            Course course = new Course
            {
                CourseId = id,
                Title = title,
                Instructor = instructor
            };

            if (manager.AddCourse(course))
                Console.WriteLine("Course added successfully.");
            else
                Console.WriteLine("Course ID already exists.");
        }

        static void EnrollStudent(StudentManager manager)
        {
            Console.Write("Enter Student ID: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("Enter Course ID: ");
            int courseId = int.Parse(Console.ReadLine());

            if (manager.EnrollStudentInCourse(
                studentId,
                courseId))
            {
                Console.WriteLine(
                    "Student enrolled successfully.");
            }
            else
            {
                Console.WriteLine(
                    "Enrollment failed.");
            }
        }

        static void ShowAllStudents(StudentManager manager)
        {
            if (manager.Students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            foreach (Student student in manager.Students)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine(student.PrintDetails());
            }
        }

        static void ShowAllCourses(StudentManager manager)
        {
            if (manager.Courses.Count == 0)
            {
                Console.WriteLine("No courses found.");
                return;
            }

            foreach (Course course in manager.Courses)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine(course.PrintDetails());
            }
        }

        static void ShowAllInstructors(StudentManager manager)
        {
            if (manager.Instructors.Count == 0)
            {
                Console.WriteLine("No instructors found.");
                return;
            }

            foreach (Instructor instructor in manager.Instructors)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine(instructor.PrintDetails());
            }
        }

        static void FindStudent(StudentManager manager)
        {
            Console.Write("Enter Student ID or Name: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int id))
            {
                Student student = manager.FindStudent(id);

                if (student != null)
                    Console.WriteLine(student.PrintDetails());
                else
                    Console.WriteLine("Student not found.");
            }
            else
            {
                List<Student> students =
                    manager.FindStudentsByName(input);

                if (students.Count == 0)
                {
                    Console.WriteLine("Student not found.");
                    return;
                }

                foreach (Student student in students)
                {
                    Console.WriteLine(student.PrintDetails());
                    Console.WriteLine("-------------------------");
                }
            }
        }

        static void FindCourse(StudentManager manager)
        {
            Console.Write("Enter Course ID or Name: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int id))
            {
                Course course = manager.FindCourse(id);

                if (course != null)
                    Console.WriteLine(course.PrintDetails());
                else
                    Console.WriteLine("Course not found.");
            }
            else
            {
                List<Course> courses =
                    manager.FindCoursesByName(input);

                if (courses.Count == 0)
                {
                    Console.WriteLine("Course not found.");
                    return;
                }

                foreach (Course course in courses)
                {
                    Console.WriteLine(course.PrintDetails());
                    Console.WriteLine("-------------------------");
                }
            }
        }

        static void UpdateStudent(StudentManager manager)
        {
            Console.Write("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());

            Student student = manager.FindStudent(id);

            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write("Enter new name: ");
            string name = Console.ReadLine();

            Console.Write("Enter new age: ");
            int age = int.Parse(Console.ReadLine());

            if (manager.UpdateStudent(id, name, age))
                Console.WriteLine("Student updated successfully.");
        }

        static void DeleteStudent(StudentManager manager)
        {
            Console.Write("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());

            if (manager.DeleteStudent(id))
                Console.WriteLine("Student deleted successfully.");
            else
                Console.WriteLine("Student not found.");
        }

        static void CheckEnrollment(StudentManager manager)
        {
            Console.Write("Enter Student ID: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("Enter Course ID: ");
            int courseId = int.Parse(Console.ReadLine());

            bool enrolled =
                manager.IsStudentEnrolled(
                    studentId,
                    courseId);

            Console.WriteLine(
                enrolled
                    ? "Student is enrolled in this course."
                    : "Student is NOT enrolled in this course.");
        }

        static void GetInstructorByCourse(StudentManager manager)
        {
            Console.Write("Enter Course Name: ");
            string title = Console.ReadLine();

            string instructor =
                manager.GetInstructorNameByCourseName(title);

            Console.WriteLine($"Instructor: {instructor}");
        }
    }
}
 

