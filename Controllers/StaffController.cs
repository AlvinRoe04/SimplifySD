using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplifySD.DBContext;
using SimplifySD.Models;

namespace SimplifySD.Controllers;

public class StaffController : SimplifyAPIController
{
    private readonly SimplifyContext _context;
    
    public StaffController(SimplifyContext context)
    {
        _context = context;
    }

    //Login method
    [HttpPost]
    public async Task<ActionResult<Staff>> Login(Staff staff)
    {
        //Check if the staff exists
        var staffExists = await _context.Staffs.AnyAsync(s => s.Username == staff.Username && s.Password == staff.Password);
        if (!staffExists)
        {
            return NotFound();
        }

        //Return the staff
        return staff;
    }
}
