using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            // Ensure DB created
            await context.Database.EnsureCreatedAsync();

            // Create roles
            string[] roles = new[] { "Admin", "Teacher", "Student" };
            foreach (var r in roles)
            {
                if (!await roleManager.RoleExistsAsync(r))
                    await roleManager.CreateAsync(new IdentityRole(r));
            }

            // Create admin user
            var adminEmail = "admin@school.local";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new ApplicationUser { UserName = adminEmail, Email = adminEmail, FullName = "Administrator" };
                var result = await userManager.CreateAsync(adminUser, "Admin@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Seed few classrooms, students, teachers
            if (!context.ClassRooms.Any())
            {
                var c1 = new ClassRoom { Name = "Grade 10 - A", Section = "A" };
                var c2 = new ClassRoom { Name = "Grade 9 - A", Section = "A" };
                context.ClassRooms.AddRange(c1, c2);
                await context.SaveChangesAsync();

                var t1 = new Teacher { FullName = "Mrs. Sharma", EmployeeNumber = "T1001" };
                var t2 = new Teacher { FullName = "Mr. Patel", EmployeeNumber = "T1002" };
                context.Teachers.AddRange(t1, t2);
                await context.SaveChangesAsync();

                var s1 = new Student { FullName = "Ravi Kumar", DateOfBirth = new DateTime(2009, 5, 1), RollNumber = "10A001", ClassRoomId = c1.Id };
                var s2 = new Student { FullName = "Priya Singh", DateOfBirth = new DateTime(2009, 8, 15), RollNumber = "10A002", ClassRoomId = c1.Id };
                context.Students.AddRange(s1, s2);
                await context.SaveChangesAsync();

                // Subjects
                var sub1 = new Subject { Name = "Mathematics", TeacherId = t1.Id };
                var sub2 = new Subject { Name = "Science", TeacherId = t2.Id };
                context.Subjects.AddRange(sub1, sub2);
                await context.SaveChangesAsync();
            }
        }
    }
}
