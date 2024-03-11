namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.TypeMainOeuvreDuree;

[Controller]
[Route("typeMainOeuvreDuree")]
public class TypeMainOeuvreDureeController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<TypeMainOeuvreDureeController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([] TypeMainOeuvreDuree typeMainOeuvreDuree){
	 	_context.typeMainOeuvreDuree.Add(typeMainOeuvreDuree);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		#foreignKey#
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit([] TypeMainOeuvreDuree typeMainOeuvreDuree){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.TypeMainOeuvreDuree.Update(typeMainOeuvreDuree);
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
	public async Task<IActionResult> Delete([] TypeMainOeuvreDuree typeMainOeuvreDuree){
	 	if (id == null)
		{
			return NotFound();
		}
		var typeMainOeuvreDuree = await _context.TypeMainOeuvreDuree.FirstOrDefaultAsync(m => m.#primaryKeyField# == id);
		if (typeMainOeuvreDuree == null)
		{
			return NotFound();
		}
		_context.TypeMainOeuvreDuree.Remove(typeMainOeuvreDuree);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.TypeMainOeuvreDuree.ToListAsync());
	}
	public TypeMainOeuvreDureeController(RepositoryDbContext context) { _context = context; }

}
