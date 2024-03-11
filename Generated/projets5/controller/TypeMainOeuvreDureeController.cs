namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.TypeMainOeuvreDuree;

[Controller]
[Route("typeMainOeuvreDuree")]
public class TypeMainOeuvreDureeController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<TypeMainOeuvreDureeController> _logger;

	[HttpPost]
	public ActionResult<TypeMainOeuvreDuree> save([FromBody] TypeMainOeuvreDuree typeMainOeuvreDuree){
	 	_context.typeMainOeuvreDuree.Add(typeMainOeuvreDuree);
		_context.SaveChanges();
		return Ok();
	}
	[HttpPut]
	public ActionResult<TypeMainOeuvreDuree> update([FromBody] TypeMainOeuvreDuree typeMainOeuvreDuree){
	 	var temp = typeMainOeuvreDuree;
		_context.SaveChanges();
		return Ok();
	}
	[HttpDelete]
	public void delete([FromBody] TypeMainOeuvreDuree typeMainOeuvreDuree){
	 	_context.TypeMainOeuvreDuree.Remove(typeMainOeuvreDuree);
		_context.SaveChanges();	return Ok();
	}
	[HttpGet]
	public ActionResult<IEnumerable<TypeMainOeuvreDuree>> findAll(){
	 	return Ok(_context.TypeMainOeuvreDuree.ToList());
	}
	public TypeMainOeuvreDureeController(RepositoryDbContext context) { _context = context; }

}
