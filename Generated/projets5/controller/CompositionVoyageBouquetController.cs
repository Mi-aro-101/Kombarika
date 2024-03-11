namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.CompositionVoyageBouquet;

[Controller]
[Route("compositionVoyageBouquet")]
public class CompositionVoyageBouquetController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<CompositionVoyageBouquetController> _logger;

	[HttpPost]
	public ActionResult<CompositionVoyageBouquet> save([FromBody] CompositionVoyageBouquet compositionVoyageBouquet){
	 	_context.compositionVoyageBouquet.Add(compositionVoyageBouquet);
		_context.SaveChanges();
		return Ok();
	}
	[HttpPut]
	public ActionResult<CompositionVoyageBouquet> update([FromBody] CompositionVoyageBouquet compositionVoyageBouquet){
	 	var temp = compositionVoyageBouquet;
		_context.SaveChanges();
		return Ok();
	}
	[HttpDelete]
	public void delete([FromBody] CompositionVoyageBouquet compositionVoyageBouquet){
	 	_context.CompositionVoyageBouquet.Remove(compositionVoyageBouquet);
		_context.SaveChanges();	return Ok();
	}
	[HttpGet]
	public ActionResult<IEnumerable<CompositionVoyageBouquet>> findAll(){
	 	return Ok(_context.CompositionVoyageBouquet.ToList());
	}
	public CompositionVoyageBouquetController(RepositoryDbContext context) { _context = context; }

}
