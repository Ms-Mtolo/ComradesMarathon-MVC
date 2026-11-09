using System.Security.Claims;
using ComradesMarathonAPI.Controllers;
using ComradesMarathonAPI.Data;
using ComradesMarathonAPI.DTOs;
using ComradesMarathonAPI.Models;
using ComradesMarathonAPI.Services;    // <-- ADDED
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;   // <-- ADDED
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ComradesMarathonAPI.Tests;

public class EventsControllerTests
{
    // Helper: build an AppDbContext backed by EF Core InMemory
    private static AppDbContext CreateDb(string dbName)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(dbName)
            .Options;
        return new AppDbContext(options);
    }

    // Helper: build a BlobService with a fake (in-memory) configuration.
    // Tests never call UploadAsync, so the connection string value is irrelevant.
    private static BlobService CreateBlobService()
    {
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["ConnectionStrings:AzureBlobStorage"] = "UseDevelopmentStorage=true"
            })
            .Build();

        return new BlobService(config);
    }

    // Helper: build a controller with a fake logged-in user
    private static EventsController CreateController(AppDbContext db, int userId, string role)
    {
        var controller = new EventsController(db, CreateBlobService());   // <-- CHANGED

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, userId.ToString()),
            new(ClaimTypes.Role, role)
        };
        var identity = new ClaimsIdentity(claims, "TestAuth");
        var principal = new ClaimsPrincipal(identity);

        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = principal }
        };

        return controller;
    }

    // ... rest of the test methods unchanged ...
}