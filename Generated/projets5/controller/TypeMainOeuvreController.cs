namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.TypeMainOeuvre;

[Controller]
[Route("typeMainOeuvre")]
public class TypeMainOeuvreController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<TypeMainOeuvreController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([] TypeMainOeuvre typeMainOeuvre){
	 	_context.typeMainOeuvre.Add(typeMainOeuvre);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		#foreignKey#
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit([] TypeMainOeuvre typeMainOeuvre){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.TypeMainOeuvre.Update(typeMainOeuvre);
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
	public async Task<IActionResult> Delete([] TypeMainOeuvre typeMainOeuvre){
	 	if (id == null)
		{
			return NotFound();
		}
		var typeMainOeuvre = await _context.TypeMainOeuvre.FirstOrDefaultAsync(m => m.#primaryKeyField# == id);
		if (typeMainOeuvre == null)
		{
			return NotFound();
		}
		_context.TypeMainOeuvre.Remove(typeMainOeuvre);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.TypeMainOeuvre.ToListAsync());
	}
	public TypeMainOeuvreController(RepositoryDbContext context) { _context = context; }

}
