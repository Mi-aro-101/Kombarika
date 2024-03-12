namespace projets5.controller;

using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projets5.repository.RepositoryDbContext;
using Microsoft.EntityFrameworkCore;
using projets5.entity.CompositionVoyageBouquet;

[Controller]
[Route("compositionVoyageBouquet")]
public class CompositionVoyageBouquetController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<CompositionVoyageBouquetController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([Bind("voyageIdCompositionVoyageBouquet,nombreFois,activiteIdCompositionVoyageBouquet,typeDureeIdCompositionVoyageBouquet,bouquetIdCompositionVoyageBouquet")] CompositionVoyageBouquet compositionVoyageBouquet){
	 	_context.CompositionVoyageBouquet.Add(compositionVoyageBouquet);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		
		ViewData["voyageIdCompositionVoyageBouquet"] = await _context.Voyage.ToListAsync();
		
		ViewData["activiteIdCompositionVoyageBouquet"] = await _context.Activite.ToListAsync();
		
		ViewData["typeDureeIdCompositionVoyageBouquet"] = await _context.TypeDuree.ToListAsync();
		
		ViewData["bouquetIdCompositionVoyageBouquet"] = await _context.Bouquet.ToListAsync();
		
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit(int? id, [Bind("voyageIdCompositionVoyageBouquet,nombreFois,activiteIdCompositionVoyageBouquet,typeDureeIdCompositionVoyageBouquet,bouquetIdCompositionVoyageBouquet")] CompositionVoyageBouquet compositionVoyageBouquet){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.CompositionVoyageBouquet.Update(compositionVoyageBouquet);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Edit(int? id)
	{
		if (id == null)
		{
			return NotFound();
		}
		var compositionVoyageBouquet = await _context.CompositionVoyageBouquet.FirstOrDefaultAsync(m => m. == id);
		if (compositionVoyageBouquet == null)
		{
			return NotFound();
		}
		
		ViewData["voyageIdCompositionVoyageBouquet"] = await _context.Voyage.ToListAsync();
		
		ViewData["activiteIdCompositionVoyageBouquet"] = await _context.Activite.ToListAsync();
		
		ViewData["typeDureeIdCompositionVoyageBouquet"] = await _context.TypeDuree.ToListAsync();
		
		ViewData["bouquetIdCompositionVoyageBouquet"] = await _context.Bouquet.ToListAsync();
		
		return View(compositionVoyageBouquet);
	}
	[HttpGet]
	public async Task<IActionResult> Delete(int? id){
	 	if (id == null)
		{
			return NotFound();
		}
		var compositionVoyageBouquet = await _context.CompositionVoyageBouquet.FirstOrDefaultAsync(m => m. == id);
		if (compositionVoyageBouquet == null)
		{
			return NotFound();
		}
		_context.CompositionVoyageBouquet.Remove(compositionVoyageBouquet);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.CompositionVoyageBouquet.ToListAsync());
	}
	public CompositionVoyageBouquetController(RepositoryDbContext context) { _context = context; }

}
