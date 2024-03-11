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
	public async Task<IActionResult> Create([] Client client){
	 	_context.client.Add(client);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		#foreignKey#
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit([] Client client){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.Client.Update(client);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Edit()
	{
		if (id == null)
		{
			return NotFound();
		}
		var #object# = await _context.?.FirstOrDefaultAsync(m => m.#primaryKeyField# == id);
		if (#object# == null)
		{
			return NotFound();
		}
		#foreignKey#
		return View(#object#);
	}
	[HttpGet]
	public async Task<IActionResult> Delete([] Client client){
	 	if (id == null)
		{
			return NotFound();
		}
		var client = await _context.Client.FirstOrDefaultAsync(m => m.#primaryKeyField# == id);
		if (client == null)
		{
			return NotFound();
		}
		_context.Client.Remove(client);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.Client.ToListAsync());
	}
	public ClientController(RepositoryDbContext context) { _context = context; }

}
