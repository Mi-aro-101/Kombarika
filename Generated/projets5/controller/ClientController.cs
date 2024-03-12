namespace projets5.controller;

using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projets5.repository.RepositoryDbContext;
using Microsoft.EntityFrameworkCore;
using projets5.entity.Client;

[Controller]
[Route("client")]
public class ClientController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<ClientController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([Bind("sexe,nom,prenom,clientId")] Client client){
	 	_context.Client.Add(client);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit(int? id, [Bind("sexe,nom,prenom,clientId")] Client client){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.Client.Update(client);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Edit(int? id)
	{
		if (id == null)
		{
			return NotFound();
		}
		var client = await _context.Client.FirstOrDefaultAsync(m => m.clientId == id);
		if (client == null)
		{
			return NotFound();
		}
		
		return View(client);
	}
	[HttpGet]
	public async Task<IActionResult> Delete(int? id){
	 	if (id == null)
		{
			return NotFound();
		}
		var client = await _context.Client.FirstOrDefaultAsync(m => m.clientId == id);
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
