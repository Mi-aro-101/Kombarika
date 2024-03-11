namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.Personnel;

[Controller]
[Route("personnel")]
public class PersonnelController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<PersonnelController> _logger;

	[HttpPost]
	public ActionResult<Personnel> save([FromBody] Personnel personnel){
	 	_context.personnel.Add(personnel);
		_context.SaveChanges();
		return Ok();
	}
	[HttpPut]
	public ActionResult<Personnel> update([FromBody] Personnel personnel){
	 	var temp = personnel;
		_context.SaveChanges();
		return Ok();
	}
	[HttpDelete]
	public void delete([FromBody] Personnel personnel){
	 	_context.Personnel.Remove(personnel);
		_context.SaveChanges();	return Ok();
	}
	[HttpGet]
	public ActionResult<IEnumerable<Personnel>> findAll(){
	 	return Ok(_context.Personnel.ToList());
	}
	public PersonnelController(RepositoryDbContext context) { _context = context; }

}
