namespace projets5.controller;

using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projets5.repository.RepositoryDbContext;
using Microsoft.EntityFrameworkCore;
using projets5.entity.Activite;

[Controller]
[Route("activite")]
public class ActiviteController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<ActiviteController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([Bind("activiteId,nomActivite,prixUnitaire")] Activite activite){
	 	_context.Activite.Add(activite);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit(int? id, [Bind("activiteId,nomActivite,prixUnitaire")] Activite activite){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.Activite.Update(activite);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Edit(int? id)
	{
		if (id == null)
		{
			return NotFound();
		}
		var activite = await _context.Activite.FirstOrDefaultAsync(m => m.activiteId == id);
		if (activite == null)
		{
			return NotFound();
		}
		
		return View(activite);
	}
	[HttpGet]
	public async Task<IActionResult> Delete(int? id){
	 	if (id == null)
		{
			return NotFound();
		}
		var activite = await _context.Activite.FirstOrDefaultAsync(m => m.activiteId == id);
		if (activite == null)
		{
			return NotFound();
		}
		_context.Activite.Remove(activite);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.Activite.ToListAsync());
	}
	public ActiviteController(RepositoryDbContext context) { _context = context; }

}
