namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.Bouquet;

[Controller]
[Route("bouquet")]
public class BouquetController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<BouquetController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([] Bouquet bouquet){
	 	_context.bouquet.Add(bouquet);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		#foreignKey#
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit([] Bouquet bouquet){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.Bouquet.Update(bouquet);
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
	public async Task<IActionResult> Delete([] Bouquet bouquet){
	 	if (id == null)
		{
			return NotFound();
		}
		var bouquet = await _context.Bouquet.FirstOrDefaultAsync(m => m.#primaryKeyField# == id);
		if (bouquet == null)
		{
			return NotFound();
		}
		_context.Bouquet.Remove(bouquet);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.Bouquet.ToListAsync());
	}
	public BouquetController(RepositoryDbContext context) { _context = context; }

}
