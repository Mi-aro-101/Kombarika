namespace projets5.controller;

using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projets5.repository.RepositoryDbContext;
using Microsoft.EntityFrameworkCore;
using projets5.entity.Bouquet;

[Controller]
[Route("bouquet")]
public class BouquetController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<BouquetController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([Bind("bouquetId,nomBouquet,heureTravail")] Bouquet bouquet){
	 	_context.Bouquet.Add(bouquet);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit(int? id, [Bind("bouquetId,nomBouquet,heureTravail")] Bouquet bouquet){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.Bouquet.Update(bouquet);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Edit(int? id)
	{
		if (id == null)
		{
			return NotFound();
		}
		var bouquet = await _context.Bouquet.FirstOrDefaultAsync(m => m.bouquetId == id);
		if (bouquet == null)
		{
			return NotFound();
		}
		
		return View(bouquet);
	}
	[HttpGet]
	public async Task<IActionResult> Delete(int? id){
	 	if (id == null)
		{
			return NotFound();
		}
		var bouquet = await _context.Bouquet.FirstOrDefaultAsync(m => m.bouquetId == id);
		if (bouquet == null)
		{
			return NotFound();
		}
		_context.Bouquet.Remove(bouquet);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.Bouquet.ToListAsync());
	}
	public BouquetController(RepositoryDbContext context) { _context = context; }

}
