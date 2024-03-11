namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.Parametre;

[Controller]
[Route("parametre")]
public class ParametreController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<ParametreController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([] Parametre parametre){
	 	_context.parametre.Add(parametre);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		#foreignKey#
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit([] Parametre parametre){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.Parametre.Update(parametre);
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
	public async Task<IActionResult> Delete([] Parametre parametre){
	 	if (id == null)
		{
			return NotFound();
		}
		var parametre = await _context.Parametre.FirstOrDefaultAsync(m => m.#primaryKeyField# == id);
		if (parametre == null)
		{
			return NotFound();
		}
		_context.Parametre.Remove(parametre);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.Parametre.ToListAsync());
	}
	public ParametreController(RepositoryDbContext context) { _context = context; }

}
