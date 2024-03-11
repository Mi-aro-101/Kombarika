namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.Bouquet;

[Controller]
[Route("bouquet")]
public class BouquetController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<BouquetController> _logger;

	[HttpPost]
	public ActionResult<Bouquet> save([FromBody] Bouquet bouquet){
	 	_context.bouquet.Add(bouquet);
		_context.SaveChanges();
		return Ok();
	}
	[HttpPut]
	public ActionResult<Bouquet> update([FromBody] Bouquet bouquet){
	 	var temp = bouquet;
		_context.SaveChanges();
		return Ok();
	}
	[HttpDelete]
	public void delete([FromBody] Bouquet bouquet){
	 	_context.Bouquet.Remove(bouquet);
		_context.SaveChanges();	return Ok();
	}
	[HttpGet]
	public ActionResult<IEnumerable<Bouquet>> findAll(){
	 	return Ok(_context.Bouquet.ToList());
	}
	public BouquetController(RepositoryDbContext context) { _context = context; }

}
