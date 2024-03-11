namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.BouquetActivite;

[Controller]
[Route("bouquetActivite")]
public class BouquetActiviteController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<BouquetActiviteController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([] BouquetActivite bouquetActivite){
	 	_context.bouquetActivite.Add(bouquetActivite);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		#foreignKey#
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit([] BouquetActivite bouquetActivite){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.BouquetActivite.Update(bouquetActivite);
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
	public async Task<IActionResult> Delete([] BouquetActivite bouquetActivite){
	 	if (id == null)
		{
			return NotFound();
		}
		var bouquetActivite = await _context.BouquetActivite.FirstOrDefaultAsync(m => m.#primaryKeyField# == id);
		if (bouquetActivite == null)
		{
			return NotFound();
		}
		_context.BouquetActivite.Remove(bouquetActivite);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.BouquetActivite.ToListAsync());
	}
	public BouquetActiviteController(RepositoryDbContext context) { _context = context; }

}
