namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.TypeDuree;

[Controller]
[Route("typeDuree")]
public class TypeDureeController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<TypeDureeController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([] TypeDuree typeDuree){
	 	_context.typeDuree.Add(typeDuree);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		#foreignKey#
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit([] TypeDuree typeDuree){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.TypeDuree.Update(typeDuree);
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
	public async Task<IActionResult> Delete([] TypeDuree typeDuree){
	 	if (id == null)
		{
			return NotFound();
		}
		var typeDuree = await _context.TypeDuree.FirstOrDefaultAsync(m => m.#primaryKeyField# == id);
		if (typeDuree == null)
		{
			return NotFound();
		}
		_context.TypeDuree.Remove(typeDuree);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.TypeDuree.ToListAsync());
	}
	public TypeDureeController(RepositoryDbContext context) { _context = context; }

}
