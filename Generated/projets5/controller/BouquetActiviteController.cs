namespace projets5.controller;

using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projets5.repository.RepositoryDbContext;
using Microsoft.EntityFrameworkCore;
using projets5.entity.BouquetActivite;

[Controller]
[Route("bouquetActivite")]
public class BouquetActiviteController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<BouquetActiviteController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([Bind("activiteIdBouquetActivite,bouquetIdBouquetActivite")] BouquetActivite bouquetActivite){
	 	_context.BouquetActivite.Add(bouquetActivite);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		
		ViewData["activiteIdBouquetActivite"] = await _context.Activite.ToListAsync();
		
		ViewData["bouquetIdBouquetActivite"] = await _context.Bouquet.ToListAsync();
		
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit(int? id, [Bind("activiteIdBouquetActivite,bouquetIdBouquetActivite")] BouquetActivite bouquetActivite){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.BouquetActivite.Update(bouquetActivite);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Edit(int? id)
	{
		if (id == null)
		{
			return NotFound();
		}
		var bouquetActivite = await _context.BouquetActivite.FirstOrDefaultAsync(m => m. == id);
		if (bouquetActivite == null)
		{
			return NotFound();
		}
		
		ViewData["activiteIdBouquetActivite"] = await _context.Activite.ToListAsync();
		
		ViewData["bouquetIdBouquetActivite"] = await _context.Bouquet.ToListAsync();
		
		return View(bouquetActivite);
	}
	[HttpGet]
	public async Task<IActionResult> Delete(int? id){
	 	if (id == null)
		{
			return NotFound();
		}
		var bouquetActivite = await _context.BouquetActivite.FirstOrDefaultAsync(m => m. == id);
		if (bouquetActivite == null)
		{
			return NotFound();
		}
		_context.BouquetActivite.Remove(bouquetActivite);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.BouquetActivite.ToListAsync());
	}
	public BouquetActiviteController(RepositoryDbContext context) { _context = context; }

}
