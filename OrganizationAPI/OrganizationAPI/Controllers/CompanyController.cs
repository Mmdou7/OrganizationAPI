using Microsoft.AspNetCore.Mvc;
using Organization.Domain.Company.Models;

namespace Organization.Presentation.API.Controllers;


[ApiController]
[Route("Api/[controller]")]
public sealed class CompanyController : ControllerBase
{
    private readonly List<Company> _companies;
    public CompanyController()
    {
        _companies = new List<Company>
        {
            new Company(){Id = "TestID001" , Name = "First"},
            new Company(){Id = "TestID002" , Name = "Second"},
            new Company(){Id = "TestID003" , Name = "Third"},
            new Company(){Id = "TestID004" , Name = "Forth"}
        };
         
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCompanies()
    {
        await Task.CompletedTask;
        return Ok(_companies);
    }
    [HttpGet("getCompany/{id:length(9)}")]
    public async Task<IActionResult> GetCompanyById(string id)
    {
        var reqCompany = _companies.Find(x=>x.Id == id);
        await Task.CompletedTask;

        if (reqCompany == null)

            return NotFound();
        

        return Ok(reqCompany);
    }
    [HttpPost("addCompany")]
    public async Task<IActionResult> AddCompany(Company company)
    {
        _companies.Add(company);
        await Task.CompletedTask;

        return CreatedAtAction("GetCompanyById", new { id = company.Id }, company );
    }
    [HttpDelete("deleteCompany/{id:length(9)}")]
    public async Task<IActionResult> DeleteCompany(string id)
    {
        var reqCompany = _companies.Find(x => x.Id == id);

        if (reqCompany == null) return NotFound(reqCompany);

        _companies.Remove(reqCompany);
        await Task.CompletedTask;

        return NoContent();
    }
    [HttpPut("updateCompany/{id:length(9)}")]
    public async Task<IActionResult> UpdateCompany(string id, [FromBody] Company company)
    {
        var reqCompany = _companies.Find(x => x.Id == id);
        await Task.CompletedTask;

        if(id != company.Id) return BadRequest(company.Id);

        if(reqCompany == null) return NotFound(reqCompany);

        reqCompany.Name = company.Name;
        return NoContent();
        
    }
}
