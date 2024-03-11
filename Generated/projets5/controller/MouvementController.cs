namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.Mouvement;

[Controller]
[Route("mouvement")]
public class MouvementController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<MouvementController> _logger;

	[HttpPost]
	public ActionResult<Mouvement> save([FromBody] Mouvement mouvement){
	 	_context.mouvement.Add(mouvement);
		_context.SaveChanges();
		return Ok();
	}
	[HttpPut]
	public ActionResult<Mouvement> update([FromBody] Mouvement mouvement){
	 	var temp = mouvement;
		_context.SaveChanges();
		return Ok();
	}
	[HttpDelete]
	public void delete([FromBody] Mouvement mouvement){
	 	_context.Mouvement.Remove(mouvement);
		_context.SaveChanges();	return Ok();
	}
	[HttpGet]
	public ActionResult<IEnumerable<Mouvement>> findAll(){
	 	return Ok(_context.Mouvement.ToList());
	}
	public MouvementController(RepositoryDbContext context) { _context = context; }

}
