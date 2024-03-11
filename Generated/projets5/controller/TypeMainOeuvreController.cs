namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.TypeMainOeuvre;

[Controller]
[Route("typeMainOeuvre")]
public class TypeMainOeuvreController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<TypeMainOeuvreController> _logger;

	[HttpPost]
	public ActionResult<TypeMainOeuvre> save([FromBody] TypeMainOeuvre typeMainOeuvre){
	 	_context.typeMainOeuvre.Add(typeMainOeuvre);
		_context.SaveChanges();
		return Ok();
	}
	[HttpPut]
	public ActionResult<TypeMainOeuvre> update([FromBody] TypeMainOeuvre typeMainOeuvre){
	 	var temp = typeMainOeuvre;
		_context.SaveChanges();
		return Ok();
	}
	[HttpDelete]
	public void delete([FromBody] TypeMainOeuvre typeMainOeuvre){
	 	_context.TypeMainOeuvre.Remove(typeMainOeuvre);
		_context.SaveChanges();	return Ok();
	}
	[HttpGet]
	public ActionResult<IEnumerable<TypeMainOeuvre>> findAll(){
	 	return Ok(_context.TypeMainOeuvre.ToList());
	}
	public TypeMainOeuvreController(RepositoryDbContext context) { _context = context; }

}
