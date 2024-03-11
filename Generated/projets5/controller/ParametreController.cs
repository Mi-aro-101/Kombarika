namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.Parametre;

[Controller]
[Route("parametre")]
public class ParametreController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<ParametreController> _logger;

	[HttpPost]
	public ActionResult<Parametre> save([FromBody] Parametre parametre){
	 	_context.parametre.Add(parametre);
		_context.SaveChanges();
		return Ok();
	}
	[HttpPut]
	public ActionResult<Parametre> update([FromBody] Parametre parametre){
	 	var temp = parametre;
		_context.SaveChanges();
		return Ok();
	}
	[HttpDelete]
	public void delete([FromBody] Parametre parametre){
	 	_context.Parametre.Remove(parametre);
		_context.SaveChanges();	return Ok();
	}
	[HttpGet]
	public ActionResult<IEnumerable<Parametre>> findAll(){
	 	return Ok(_context.Parametre.ToList());
	}
	public ParametreController(RepositoryDbContext context) { _context = context; }

}
