namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.Activite;

[Controller]
[Route("activite")]
public class ActiviteController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<ActiviteController> _logger;

	[HttpPost]
	public ActionResult<Activite> save([FromBody] Activite activite){
	 	_context.activite.Add(activite);
		_context.SaveChanges();
		return Ok();
	}
	[HttpPut]
	public ActionResult<Activite> update([FromBody] Activite activite){
	 	var temp = activite;
		_context.SaveChanges();
		return Ok();
	}
	[HttpDelete]
	public void delete([FromBody] Activite activite){
	 	_context.Activite.Remove(activite);
		_context.SaveChanges();	return Ok();
	}
	[HttpGet]
	public ActionResult<IEnumerable<Activite>> findAll(){
	 	return Ok(_context.Activite.ToList());
	}
	public ActiviteController(RepositoryDbContext context) { _context = context; }

}
