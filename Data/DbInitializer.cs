using SchoolManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SchoolManagement.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Ensure database is created/migrated
            context.Database.EnsureCreated();

            // 1. Check if any data exists to avoid re-seeding
            if (context.Students.Any() || context.Teachers.Any())
            {
                return; // DB has been seeded
            }

            // --- Roles and Users (Standard Identity Seeding, placeholder) ---
            string[] roleNames = { "Admin", "Teacher", "Student" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // --- Core Entity Seeding ---

            // 2. ClassRooms must be created first
            var classrooms = new ClassRoom[]
            {
                new ClassRoom { Name = "Grade 9", Section = "A" },
                new ClassRoom { Name = "Grade 10", Section = "B" },
                new ClassRoom { Name = "Grade 11", Section = "Science" }
            };
            context.ClassRooms.AddRange(classrooms);
            await context.SaveChangesAsync();

            // 3. Teachers must be created second
            var teachers = new Teacher[]
            {
                new Teacher { FullName = "Mr. Alan Turing", EmployeeNumber = "T101" },
                new Teacher { FullName = "Ms. Grace Hopper", EmployeeNumber = "T102" },
                new Teacher { FullName = "Prof. Marie Curie", EmployeeNumber = "T103" }
            };
            context.Teachers.AddRange(teachers);
            await context.SaveChangesAsync();


            // 4. Students - FIX CS9035: Must set the ClassRoom navigation property
            var students = new Student[]
            {
                // **FIXED LINE 51 (APPROX): SETTING BOTH ClassRoomId AND ClassRoom**
                new Student
                {
                    FullName = "Alice Johnson",
                    DateOfBirth = new DateTime(2008, 9, 15),
                    RollNumber = "S9A001",
                    ClassRoomId = classrooms[0].Id,
                    ClassRoom = classrooms[0]
                },
                // **FIXED LINE 52 (APPROX): SETTING BOTH ClassRoomId AND ClassRoom**
                new Student
                {
                    FullName = "Bob Williams",
                    DateOfBirth = new DateTime(2007, 5, 20),
                    RollNumber = "S10B002",
                    ClassRoomId = classrooms[1].Id,
                    ClassRoom = classrooms[1]
                },
                new Student
                {
                    FullName = "Charlie Brown",
                    DateOfBirth = new DateTime(2006, 11, 1),
                    RollNumber = "S11C003",
                    ClassRoomId = classrooms[2].Id,
                    ClassRoom = classrooms[2]
                }
            };
            context.Students.AddRange(students);
            await context.SaveChangesAsync();


            // 5. Subjects - FIX CS9035: Must set the Teacher navigation property
            var subjects = new Subject[]
            {
                // **FIXED LINE 57 (APPROX): SETTING BOTH TeacherId AND Teacher**
                new Subject
                {
                    Name = "Calculus I",
                    TeacherId = teachers[0].Id,
                    Teacher = teachers[0]
                },
                // **FIXED LINE 58 (APPROX): SETTING BOTH TeacherId AND Teacher**
                new Subject
                {
                    Name = "Chemistry",
                    TeacherId = teachers[2].Id,
                    Teacher = teachers[2]
                },
                new Subject
                {
                    Name = "History",
                    TeacherId = teachers[1].Id,
                    Teacher = teachers[1]
                }
            };
            context.Subjects.AddRange(subjects);
            await context.SaveChangesAsync();

            // 6. Enrollments
            var enrollments = new Enrollment[]
            {
                // Alice enrolled in Calculus
                new Enrollment { Student = students[0], Subject = subjects[0] }, 
                // Bob enrolled in Chemistry
                new Enrollment { Student = students[1], Subject = subjects[1] }
            };
            context.Enrollments.AddRange(enrollments);
            await context.SaveChangesAsync();

            // 7. Attendance (Example Record)
            var attendanceRecords = new Attendance[]
            {
                new Attendance { Student = students[0], Date = DateTime.Today.AddDays(-1), IsPresent = true, ClassRoom = classrooms[0] },
                new Attendance { Student = students[1], Date = DateTime.Today.AddDays(-1), IsPresent = false, ClassRoom = classrooms[1] }
            };
            context.Attendances.AddRange(attendanceRecords);
            await context.SaveChangesAsync();

            // 8. Final save
            await context.SaveChangesAsync();
        }
    }
}