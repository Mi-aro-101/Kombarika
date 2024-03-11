namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.BouquetActivite;

[Controller]
[Route("bouquetActivite")]
public class BouquetActiviteController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<BouquetActiviteController> _logger;

	[HttpPost]
	public ActionResult<BouquetActivite> save([FromBody] BouquetActivite bouquetActivite){
	 	_context.bouquetActivite.Add(bouquetActivite);
		_context.SaveChanges();
		return Ok();
	}
	[HttpPut]
	public ActionResult<BouquetActivite> update([FromBody] BouquetActivite bouquetActivite){
	 	var temp = bouquetActivite;
		_context.SaveChanges();
		return Ok();
	}
	[HttpDelete]
	public void delete([FromBody] BouquetActivite bouquetActivite){
	 	_context.BouquetActivite.Remove(bouquetActivite);
		_context.SaveChanges();	return Ok();
	}
	[HttpGet]
	public ActionResult<IEnumerable<BouquetActivite>> findAll(){
	 	return Ok(_context.BouquetActivite.ToList());
	}
	public BouquetActiviteController(RepositoryDbContext context) { _context = context; }

}
