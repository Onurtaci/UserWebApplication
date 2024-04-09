using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.Models.Entities;

namespace WebApp.Controllers;

public class UsersController : Controller
{
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserViewModel viewModel, IFormFile? formFile)
    {
        User user = new()
        {
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            Email = viewModel.Email,
            Phone = viewModel.Phone,
            Password = viewModel.Password
        };

        if (formFile is not null && formFile.Length > 0)
        {
            using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            user.ProfileImage = memoryStream.ToArray();
        }

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return RedirectToAction("List", "Users");
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        List<User> users = await _context.Users.ToListAsync();
        return View(users);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        User userFromDb = await _context.Users.FindAsync(id);
        if (userFromDb == null)
        {
            return NotFound();
        }
        return View(userFromDb);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditUserViewModel viewModel, IFormFile? formFile)
    {
        var user = await _context.Users.FindAsync(viewModel.Id);
        if (user == null)
        {
            return NotFound();
        }

        if (formFile is not null && formFile.Length > 0)
        {
            using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            user.ProfileImage = memoryStream.ToArray();
        }

        user.FirstName = viewModel.FirstName;
        user.LastName = viewModel.LastName;
        user.Email = viewModel.Email;
        user.Phone = viewModel.Phone;
        user.Password = viewModel.Password;

        await _context.SaveChangesAsync();
        return RedirectToAction("List", "Users");
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        User userFromDb = await _context.Users.FindAsync(id);
        if (userFromDb == null)
        {
            return NotFound();
        }

        _context.Users.Remove(userFromDb);
        await _context.SaveChangesAsync();
        return RedirectToAction("List", "Users");
    }

    public IActionResult ProfilePicture(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null || user.ProfileImage == null)
        {
            return NotFound();
        }

        return File(user.ProfileImage, "image/jpeg");
    }

}

