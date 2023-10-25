using CabeITELEC1C.Models;
using Microsoft.EntityFrameworkCore;

namespace CabeITELEC1C.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    FirstName = "Gabriel",
                    LastName = "Montano",
                    Course = Course.BSIT,
                    AdmissionDate = DateTime.Parse("2022-08-26"),
                    GPA = 1.5,
                    Email = "ghaby021@gmail.com"
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Zyx",
                    LastName = "Montano",
                    Course = Course.BSIS,
                    AdmissionDate = DateTime.Parse("2022-08-07"),
                    GPA = 1,
                    Email = "zyx@gmail.com"
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "Aerdriel",
                    LastName = "Montano",
                    Course = Course.BSCS,
                    AdmissionDate = DateTime.Parse("2020-01-25"),
                    GPA = 1.5,
                    Email = "aerdriel@gmail.com"
                });

            modelBuilder.Entity<Instructor>().HasData(
                 new Instructor()
                 {
                     Id = 1,
                     FirstName = "Gabriel",
                     LastName = "Montano",
                     IsTenured = true,
                     HiringDate = DateTime.Parse("2022-08-26"),
                     Rank = Rank.AssistantProfessor
                 },
                new Instructor()
                {
                    Id = 2,
                    FirstName = "Zyx",
                    LastName = "Montano",
                    IsTenured = false,
                    HiringDate = DateTime.Parse("2022-08-07"),
                    Rank = Rank.Instructor
                });
        }
    }
}
