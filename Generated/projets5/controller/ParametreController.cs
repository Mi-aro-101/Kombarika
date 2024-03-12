namespace projets5.controller;

using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projets5.repository.RepositoryDbContext;
using Microsoft.EntityFrameworkCore;
using projets5.entity.Parametre;

[Controller]
[Route("parametre")]
public class ParametreController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<ParametreController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([Bind("parametreId,valeur,libelle")] Parametre parametre){
	 	_context.Parametre.Add(parametre);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit(int? id, [Bind("parametreId,valeur,libelle")] Parametre parametre){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.Parametre.Update(parametre);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Edit(int? id)
	{
		if (id == null)
		{
			return NotFound();
		}
		var parametre = await _context.Parametre.FirstOrDefaultAsync(m => m.parametreId == id);
		if (parametre == null)
		{
			return NotFound();
		}
		
		return View(parametre);
	}
	[HttpGet]
	public async Task<IActionResult> Delete(int? id){
	 	if (id == null)
		{
			return NotFound();
		}
		var parametre = await _context.Parametre.FirstOrDefaultAsync(m => m.parametreId == id);
		if (parametre == null)
		{
			return NotFound();
		}
		_context.Parametre.Remove(parametre);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.Parametre.ToListAsync());
	}
	public ParametreController(RepositoryDbContext context) { _context = context; }

}
