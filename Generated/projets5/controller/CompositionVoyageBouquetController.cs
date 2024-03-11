namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.CompositionVoyageBouquet;

[Controller]
[Route("compositionVoyageBouquet")]
public class CompositionVoyageBouquetController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<CompositionVoyageBouquetController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([] CompositionVoyageBouquet compositionVoyageBouquet){
	 	_context.compositionVoyageBouquet.Add(compositionVoyageBouquet);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		#foreignKey#
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit([] CompositionVoyageBouquet compositionVoyageBouquet){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.CompositionVoyageBouquet.Update(compositionVoyageBouquet);
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
	public async Task<IActionResult> Delete([] CompositionVoyageBouquet compositionVoyageBouquet){
	 	if (id == null)
		{
			return NotFound();
		}
		var compositionVoyageBouquet = await _context.CompositionVoyageBouquet.FirstOrDefaultAsync(m => m.#primaryKeyField# == id);
		if (compositionVoyageBouquet == null)
		{
			return NotFound();
		}
		_context.CompositionVoyageBouquet.Remove(compositionVoyageBouquet);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.CompositionVoyageBouquet.ToListAsync());
	}
	public CompositionVoyageBouquetController(RepositoryDbContext context) { _context = context; }

}
