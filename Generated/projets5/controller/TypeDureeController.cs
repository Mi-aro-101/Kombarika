namespace projets5.controller;

using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projets5.repository.RepositoryDbContext;
using Microsoft.EntityFrameworkCore;
using projets5.entity.TypeDuree;

[Controller]
[Route("typeDuree")]
public class TypeDureeController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<TypeDureeController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([Bind("nomTypeDuree,prixDuree,typeDureeId,nombreJour")] TypeDuree typeDuree){
	 	_context.TypeDuree.Add(typeDuree);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit(int? id, [Bind("nomTypeDuree,prixDuree,typeDureeId,nombreJour")] TypeDuree typeDuree){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.TypeDuree.Update(typeDuree);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Edit(int? id)
	{
		if (id == null)
		{
			return NotFound();
		}
		var typeDuree = await _context.TypeDuree.FirstOrDefaultAsync(m => m.typeDureeId == id);
		if (typeDuree == null)
		{
			return NotFound();
		}
		
		return View(typeDuree);
	}
	[HttpGet]
	public async Task<IActionResult> Delete(int? id){
	 	if (id == null)
		{
			return NotFound();
		}
		var typeDuree = await _context.TypeDuree.FirstOrDefaultAsync(m => m.typeDureeId == id);
		if (typeDuree == null)
		{
			return NotFound();
		}
		_context.TypeDuree.Remove(typeDuree);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.TypeDuree.ToListAsync());
	}
	public TypeDureeController(RepositoryDbContext context) { _context = context; }

}
