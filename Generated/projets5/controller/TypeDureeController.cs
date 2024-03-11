namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.TypeDuree;

[Controller]
[Route("typeDuree")]
public class TypeDureeController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<TypeDureeController> _logger;

	[HttpPost]
	public ActionResult<TypeDuree> save([FromBody] TypeDuree typeDuree){
	 	_context.typeDuree.Add(typeDuree);
		_context.SaveChanges();
		return Ok();
	}
	[HttpPut]
	public ActionResult<TypeDuree> update([FromBody] TypeDuree typeDuree){
	 	var temp = typeDuree;
		_context.SaveChanges();
		return Ok();
	}
	[HttpDelete]
	public void delete([FromBody] TypeDuree typeDuree){
	 	_context.TypeDuree.Remove(typeDuree);
		_context.SaveChanges();	return Ok();
	}
	[HttpGet]
	public ActionResult<IEnumerable<TypeDuree>> findAll(){
	 	return Ok(_context.TypeDuree.ToList());
	}
	public TypeDureeController(RepositoryDbContext context) { _context = context; }

}
