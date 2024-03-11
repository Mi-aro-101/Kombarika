namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.Voyage;

[Controller]
[Route("voyage")]
public class VoyageController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<VoyageController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([] Voyage voyage){
	 	_context.voyage.Add(voyage);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		#foreignKey#
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit([] Voyage voyage){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.Voyage.Update(voyage);
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
	public async Task<IActionResult> Delete([] Voyage voyage){
	 	if (id == null)
		{
			return NotFound();
		}
		var voyage = await _context.Voyage.FirstOrDefaultAsync(m => m.#primaryKeyField# == id);
		if (voyage == null)
		{
			return NotFound();
		}
		_context.Voyage.Remove(voyage);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.Voyage.ToListAsync());
	}
	public VoyageController(RepositoryDbContext context) { _context = context; }

}
