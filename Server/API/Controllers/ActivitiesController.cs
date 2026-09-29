using Domain;
using Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public sealed class ActivitiesController(ApplicationDbContext dbContext) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await dbContext.Activities.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
        var activity = await dbContext.Activities.FirstOrDefaultAsync(activity =>
            activity.Id == id
        );

        if (activity is null)
            return NotFound();

        return activity;
    }
}
