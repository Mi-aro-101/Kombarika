namespace projets5.controller;

using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projets5.repository.RepositoryDbContext;
using Microsoft.EntityFrameworkCore;
using projets5.entity.TypeMainOeuvre;

[Controller]
[Route("typeMainOeuvre")]
public class TypeMainOeuvreController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<TypeMainOeuvreController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([Bind("intervalAnneeExperience,croissanceSalaire,typeMainOeuvreId,anneeExperienceDebut,salaire,type,anneeExperienceFin")] TypeMainOeuvre typeMainOeuvre){
	 	_context.TypeMainOeuvre.Add(typeMainOeuvre);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit(int? id, [Bind("intervalAnneeExperience,croissanceSalaire,typeMainOeuvreId,anneeExperienceDebut,salaire,type,anneeExperienceFin")] TypeMainOeuvre typeMainOeuvre){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.TypeMainOeuvre.Update(typeMainOeuvre);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Edit(int? id)
	{
		if (id == null)
		{
			return NotFound();
		}
		var typeMainOeuvre = await _context.TypeMainOeuvre.FirstOrDefaultAsync(m => m.typeMainOeuvreId == id);
		if (typeMainOeuvre == null)
		{
			return NotFound();
		}
		
		return View(typeMainOeuvre);
	}
	[HttpGet]
	public async Task<IActionResult> Delete(int? id){
	 	if (id == null)
		{
			return NotFound();
		}
		var typeMainOeuvre = await _context.TypeMainOeuvre.FirstOrDefaultAsync(m => m.typeMainOeuvreId == id);
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
