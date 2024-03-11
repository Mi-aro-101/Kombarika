namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.Voyage;

[Controller]
[Route("voyage")]
public class VoyageController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<VoyageController> _logger;

	[HttpPost]
	public ActionResult<Voyage> save([FromBody] Voyage voyage){
	 	_context.voyage.Add(voyage);
		_context.SaveChanges();
		return Ok();
	}
	[HttpPut]
	public ActionResult<Voyage> update([FromBody] Voyage voyage){
	 	var temp = voyage;
		_context.SaveChanges();
		return Ok();
	}
	[HttpDelete]
	public void delete([FromBody] Voyage voyage){
	 	_context.Voyage.Remove(voyage);
		_context.SaveChanges();	return Ok();
	}
	[HttpGet]
	public ActionResult<IEnumerable<Voyage>> findAll(){
	 	return Ok(_context.Voyage.ToList());
	}
	public VoyageController(RepositoryDbContext context) { _context = context; }

}
