using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;
using SchoolManagement.Data;
using Microsoft.EntityFrameworkCore; // <--- FIX: ADD THIS USING DIRECTIVE

namespace SchoolManagement.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    // Constructor updated to receive ApplicationDbContext
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context; // Initialize context
    }

    public async Task<IActionResult> Index() // MAKE ASYNC
    {
        // 1. Get total counts (Now CountAsync() will work)
        ViewBag.TotalStudents = await _context.Students.CountAsync();
        ViewBag.TotalTeachers = await _context.Teachers.CountAsync();
        ViewBag.TotalClassRooms = await _context.ClassRooms.CountAsync();

        // 2. Calculate Today's Attendance Percentage (Example Logic)
        DateTime today = DateTime.Today;
        int totalStudents = ViewBag.TotalStudents;

        // Count unique students who have an 'IsPresent = true' record today
        int presentStudents = await _context.Attendances
            .Where(a => a.Date.Date == today && a.IsPresent == true)
            .Select(a => a.StudentId)
            .Distinct()
            .CountAsync();

        double attendancePercentage = totalStudents > 0
            ? (double)presentStudents / totalStudents * 100
            : 0;

        ViewBag.TodayAttendance = attendancePercentage.ToString("F1") + "%";

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}