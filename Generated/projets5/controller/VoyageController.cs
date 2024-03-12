namespace projets5.controller;

using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projets5.repository.RepositoryDbContext;
using Microsoft.EntityFrameworkCore;
using projets5.entity.Voyage;

[Controller]
[Route("voyage")]
public class VoyageController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<VoyageController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([Bind("nomVoyage,voyageId,prixVoyage")] Voyage voyage){
	 	_context.Voyage.Add(voyage);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit(int? id, [Bind("nomVoyage,voyageId,prixVoyage")] Voyage voyage){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.Voyage.Update(voyage);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Edit(int? id)
	{
		if (id == null)
		{
			return NotFound();
		}
		var voyage = await _context.Voyage.FirstOrDefaultAsync(m => m.voyageId == id);
		if (voyage == null)
		{
			return NotFound();
		}
		
		return View(voyage);
	}
	[HttpGet]
	public async Task<IActionResult> Delete(int? id){
	 	if (id == null)
		{
			return NotFound();
		}
		var voyage = await _context.Voyage.FirstOrDefaultAsync(m => m.voyageId == id);
		if (voyage == null)
		{
			return NotFound();
		}
		_context.Voyage.Remove(voyage);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.Voyage.ToListAsync());
	}
	public VoyageController(RepositoryDbContext context) { _context = context; }

}
