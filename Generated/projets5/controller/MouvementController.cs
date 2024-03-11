namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.Mouvement;

[Controller]
[Route("mouvement")]
public class MouvementController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<MouvementController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([] Mouvement mouvement){
	 	_context.mouvement.Add(mouvement);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		#foreignKey#
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit([] Mouvement mouvement){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.Mouvement.Update(mouvement);
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
	public async Task<IActionResult> Delete([] Mouvement mouvement){
	 	if (id == null)
		{
			return NotFound();
		}
		var mouvement = await _context.Mouvement.FirstOrDefaultAsync(m => m.#primaryKeyField# == id);
		if (mouvement == null)
		{
			return NotFound();
		}
		_context.Mouvement.Remove(mouvement);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.Mouvement.ToListAsync());
	}
	public MouvementController(RepositoryDbContext context) { _context = context; }

}
