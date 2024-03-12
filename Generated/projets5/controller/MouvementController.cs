namespace projets5.controller;

using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projets5.repository.RepositoryDbContext;
using Microsoft.EntityFrameworkCore;
using projets5.entity.Mouvement;

[Controller]
[Route("mouvement")]
public class MouvementController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<MouvementController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([Bind("activiteIdMouvement,quantiteEntree,quantiteSortie,dateHeureMouvement,mouvementId")] Mouvement mouvement){
	 	_context.Mouvement.Add(mouvement);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		
		ViewData["activiteIdMouvement"] = await _context.Activite.ToListAsync();
		
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit(int? id, [Bind("activiteIdMouvement,quantiteEntree,quantiteSortie,dateHeureMouvement,mouvementId")] Mouvement mouvement){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.Mouvement.Update(mouvement);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Edit(int? id)
	{
		if (id == null)
		{
			return NotFound();
		}
		var mouvement = await _context.Mouvement.FirstOrDefaultAsync(m => m.mouvementId == id);
		if (mouvement == null)
		{
			return NotFound();
		}
		
		ViewData["activiteIdMouvement"] = await _context.Activite.ToListAsync();
		
		return View(mouvement);
	}
	[HttpGet]
	public async Task<IActionResult> Delete(int? id){
	 	if (id == null)
		{
			return NotFound();
		}
		var mouvement = await _context.Mouvement.FirstOrDefaultAsync(m => m.mouvementId == id);
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
