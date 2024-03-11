namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.Client;

[Controller]
[Route("client")]
public class ClientController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<ClientController> _logger;

	[HttpPost]
	public ActionResult<Client> save([FromBody] Client client){
	 	_context.client.Add(client);
		_context.SaveChanges();
		return Ok();
	}
	[HttpPut]
	public ActionResult<Client> update([FromBody] Client client){
	 	var temp = client;
		_context.SaveChanges();
		return Ok();
	}
	[HttpDelete]
	public void delete([FromBody] Client client){
	 	_context.Client.Remove(client);
		_context.SaveChanges();	return Ok();
	}
	[HttpGet]
	public ActionResult<IEnumerable<Client>> findAll(){
	 	return Ok(_context.Client.ToList());
	}
	public ClientController(RepositoryDbContext context) { _context = context; }

}
