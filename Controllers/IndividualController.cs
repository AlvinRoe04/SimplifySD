using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplifySD.DBContext;
using SimplifySD.Models;

namespace SimplifySD.Controllers;
public class IndividualController : SimplifyAPIController
{
    private readonly SimplifyContext _context;

    public IndividualController(SimplifyContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Individual>>> GetIndividuals()
    {
        var individuals = await _context.Individuals.ToListAsync();
        return individuals;
    } 

    [HttpPost]
    public async Task<ActionResult<Individual>> CreateIndividual(Individual individual)
    {
        //Insert the individual into the database without ID
        _context.Individuals.Add(individual);
        await _context.SaveChangesAsync();

        //Return the individual with the ID
        return CreatedAtAction(nameof(GetIndividuals), new { id = individual.Id }, individual);
    }
}
