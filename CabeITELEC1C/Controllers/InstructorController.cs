using CabeITELEC1C.Data;
using CabeITELEC1C.Models;
//using CabeITELEC1C.Services;
using Microsoft.AspNetCore.Mvc;

namespace CabeITELEC1C.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDbContext _dbData;

        public InstructorController(AppDbContext dbData)
        {
            _dbData = dbData;
        }
        /*
        List<Instructor> InstructorList = new List<Instructor>()
        {
        new Instructor()
        {
            InstructorName = "Gabriel Montano", DateHired = DateTime.Now,
            InstructorEmail = "gdmontano@ust.edu.ph", Rank = Rank.Instructor
        },
        new Instructor()
        {
            InstructorName = "Leo Lintag", DateHired = DateTime.Parse("25/2/2002"),
            InstructorEmail = "Llintag@ust.edu.ph", Rank = Rank.AssistProf
        },
        new Instructor()
        {
            InstructorName = "Zyx Lintag", DateHired = DateTime.Parse("25/3/2000"),
            InstructorEmail = "zmontano@ust.edu.ph", Rank = Rank.Prof
        },
        };
        */
        /*
        List<Instructor> InstructorList = new List<Instructor>
            {
                new Instructor()
                {
                    Id= 1,FirstName = "Gabriel",LastName = "Montano", IsTenured = true, HiringDate = DateTime.Parse("2022-08-26"), Rank = Rank.AssistantProfessor
                },
                new Instructor()
                {
                    Id= 2,FirstName = "Zyx",LastName = "Montano", IsTenured = false, HiringDate = DateTime.Parse("2022-08-07"), Rank = Rank.Instructor
                },
            };
        */
        public IActionResult Index()
        {
            return View(_dbData.Instructors);
        }
        public IActionResult ShowDetails(int id)
        {
            //Search for the student whose id matches the given id
            Instructor? instructor = _dbData.Instructors.FirstOrDefault(st => st.Id == id);

            if (instructor != null)//was an student found?
                return View(instructor);

            return NotFound();
        }
        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddInstructor(Instructor AddInstructor)
        {
            _dbData.Instructors.Add(AddInstructor);
            _dbData.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateInstructor(int id)
        {
            Instructor? instructor = _dbData.Instructors.FirstOrDefault(st => st.Id == id);

            if (instructor != null)
                return View(instructor);

            return NotFound();
        }

        [HttpPost]
        public IActionResult UpdateInstructor(Instructor instructorChanges)
        {
            Instructor? instructor = _dbData.Instructors.FirstOrDefault(st => st.Id == instructorChanges.Id);
            if (instructor != null)
            {
                instructor.FirstName = instructorChanges.FirstName;
                instructor.LastName = instructorChanges.LastName;
                instructor.IsTenured = instructorChanges.IsTenured;
                instructor.HiringDate = instructorChanges.HiringDate;
                instructor.Rank= instructorChanges.Rank;
                _dbData.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteInstructor(int id)
        {
            Instructor? instructor = _dbData.Instructors.FirstOrDefault(st => st.Id == id);

            if (instructor != null)//was an student found?
                return View(instructor);

            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteInstructor(Instructor instructorChanges)
        {
            Instructor? instructor = _dbData.Instructors.FirstOrDefault(st => st.Id == instructorChanges.Id);
            if (instructor != null)
            {
                _dbData.Instructors.Remove(instructor);
                _dbData.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

