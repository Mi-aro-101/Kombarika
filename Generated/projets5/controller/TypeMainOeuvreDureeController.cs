namespace projets5.controller;

using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projets5.repository.RepositoryDbContext;
using Microsoft.EntityFrameworkCore;
using projets5.entity.TypeMainOeuvreDuree;

[Controller]
[Route("typeMainOeuvreDuree")]
public class TypeMainOeuvreDureeController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<TypeMainOeuvreDureeController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([Bind("typeDureeIdMainOeuvreDuree,nbMainOeuvre,typeMainOeuvreIdMainOeuvreDuree")] TypeMainOeuvreDuree typeMainOeuvreDuree){
	 	_context.TypeMainOeuvreDuree.Add(typeMainOeuvreDuree);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		
		ViewData["typeDureeIdMainOeuvreDuree"] = await _context.TypeDuree.ToListAsync();
		
		ViewData["typeMainOeuvreIdMainOeuvreDuree"] = await _context.TypeMainOeuvre.ToListAsync();
		
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit(int? id, [Bind("typeDureeIdMainOeuvreDuree,nbMainOeuvre,typeMainOeuvreIdMainOeuvreDuree")] TypeMainOeuvreDuree typeMainOeuvreDuree){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.TypeMainOeuvreDuree.Update(typeMainOeuvreDuree);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Edit(int? id)
	{
		if (id == null)
		{
			return NotFound();
		}
		var typeMainOeuvreDuree = await _context.TypeMainOeuvreDuree.FirstOrDefaultAsync(m => m. == id);
		if (typeMainOeuvreDuree == null)
		{
			return NotFound();
		}
		
		ViewData["typeDureeIdMainOeuvreDuree"] = await _context.TypeDuree.ToListAsync();
		
		ViewData["typeMainOeuvreIdMainOeuvreDuree"] = await _context.TypeMainOeuvre.ToListAsync();
		
		return View(typeMainOeuvreDuree);
	}
	[HttpGet]
	public async Task<IActionResult> Delete(int? id){
	 	if (id == null)
		{
			return NotFound();
		}
		var typeMainOeuvreDuree = await _context.TypeMainOeuvreDuree.FirstOrDefaultAsync(m => m. == id);
		if (typeMainOeuvreDuree == null)
		{
			return NotFound();
		}
		_context.TypeMainOeuvreDuree.Remove(typeMainOeuvreDuree);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.TypeMainOeuvreDuree.ToListAsync());
	}
	public TypeMainOeuvreDureeController(RepositoryDbContext context) { _context = context; }

}
