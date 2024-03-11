namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.Activite;

[Controller]
[Route("activite")]
public class ActiviteController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<ActiviteController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([] Activite activite){
	 	_context.activite.Add(activite);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		#foreignKey#
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit([] Activite activite){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.Activite.Update(activite);
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
	public async Task<IActionResult> Delete([] Activite activite){
	 	if (id == null)
		{
			return NotFound();
		}
		var activite = await _context.Activite.FirstOrDefaultAsync(m => m.#primaryKeyField# == id);
		if (activite == null)
		{
			return NotFound();
		}
		_context.Activite.Remove(activite);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.Activite.ToListAsync());
	}
	public ActiviteController(RepositoryDbContext context) { _context = context; }

}
