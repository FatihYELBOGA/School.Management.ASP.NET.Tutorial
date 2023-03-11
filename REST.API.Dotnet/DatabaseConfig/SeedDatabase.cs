using Microsoft.EntityFrameworkCore;
using School_Management.Models;

namespace School_Management.DatabaseConfig
{
    public static class SeedDatabase
    {
        public static void Seed(DataContext dataContext)
        {
            if (dataContext.Database.GetPendingMigrations().Count() == 0)
            {
                if (dataContext is DataContext)
                {
                    if( dataContext.courses.Count() == 0 && 
                        dataContext.students.Count() == 0 && 
                        dataContext.studentscourses.Count() == 0)
                    {
                        dataContext.courses.AddRange(courses);
                        dataContext.students.AddRange(students);
                        dataContext.studentscourses.AddRange(studentCourse);
                    }
                     
                    dataContext.SaveChanges();
                }
            }
        }

        private static Course[] courses =
        {
            new Course()
            {
                Name = "Math",
                IsActive= true
            },
            new Course()
            {
                Name = "Programming",
                IsActive= false
            },
            new Course()
            {
                Name = "Physics",
                IsActive= true

            },
            new Course()
            {
                Name = "Algorithm",
                IsActive= false

            }
        };

        private static Student[] students =
        {
            new Student{ 
                FirstName= "Fatih",
                LastName= "YELBOGA",
                BestCourse = courses[0],
                WorstCourse= courses[1]
            },
            new Student{ 
                FirstName= "Celal",
                LastName= "BIYIKLI",
                BestCourse = courses[1],
                WorstCourse= courses[2]
            },
            new Student{
                FirstName= "Arif",
                LastName= "SONMEZ",
                BestCourse = courses[2],
                WorstCourse= courses[3]
            },
            new Student{
                FirstName= "Burak",
                LastName= "KURT",
                BestCourse = courses[1],
                WorstCourse= courses[3]
            }
        };

        private static StudentCourse[] studentCourse =
        {
            new StudentCourse()
            {
                Student = students[0],
                Course = courses[0]
            },
            new StudentCourse()
            {
                Student = students[0],
                Course = courses[1]
            },
            new StudentCourse()
            {
                Student = students[0],
                Course = courses[2]
            },
            new StudentCourse()
            {
                Student = students[1],
                Course = courses[0]
            },
            new StudentCourse()
            {
                Student = students[1],
                Course = courses[1]
            },
            new StudentCourse()
            {
                Student = students[1],
                Course = courses[2]
            },
            new StudentCourse()
            {
                Student = students[2],
                Course = courses[1]
            },
            new StudentCourse()
            {
                Student = students[2],
                Course = courses[2]
            },
            new StudentCourse()
            {
                Student = students[2],
                Course = courses[3]
            },
            new StudentCourse()
            {
                Student = students[3],
                Course = courses[1]
            },
            new StudentCourse()
            {
                Student = students[3],
                Course = courses[2]
            },
            new StudentCourse()
            {
                Student = students[3],
                Course = courses[3]
            }
        };
    }
}
