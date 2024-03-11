namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.Personnel;

[Controller]
[Route("personnel")]
public class PersonnelController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<PersonnelController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([] Personnel personnel){
	 	_context.personnel.Add(personnel);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		#foreignKey#
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit([] Personnel personnel){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.Personnel.Update(personnel);
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
	public async Task<IActionResult> Delete([] Personnel personnel){
	 	if (id == null)
		{
			return NotFound();
		}
		var personnel = await _context.Personnel.FirstOrDefaultAsync(m => m.#primaryKeyField# == id);
		if (personnel == null)
		{
			return NotFound();
		}
		_context.Personnel.Remove(personnel);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.Personnel.ToListAsync());
	}
	public PersonnelController(RepositoryDbContext context) { _context = context; }

}
