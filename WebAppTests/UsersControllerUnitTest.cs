using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Controllers;
using WebApp.Data;
using WebApp.Models;
using WebApp.Models.Entities;

namespace WebAppTests;

[TestClass]
public class UsersControllerUnitTest
{
    private UsersController _controller;
    private ApplicationDbContext _context;

    [TestInitialize]
    public void TestInitialize()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _context = new ApplicationDbContext(options);
        _controller = new UsersController(_context);
    }

    [TestMethod]
    public void Create_ReturnsViewResult()
    {
        var result = _controller.Create();
        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }

    [TestMethod]
    public async Task List_ReturnsViewResult()
    {
        var result = await _controller.List();
        Assert.IsInstanceOfType(result, typeof(ViewResult));
    }

    [TestMethod]
    public async Task List_ReturnsListOfUsers()
    {
        var users = await _controller.List() as ViewResult;
        Assert.IsInstanceOfType(users.Model, typeof(List<User>));
    }
}
