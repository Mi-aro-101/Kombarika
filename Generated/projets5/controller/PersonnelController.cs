namespace projets5.controller;

using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projets5.repository.RepositoryDbContext;
using Microsoft.EntityFrameworkCore;
using projets5.entity.Personnel;

[Controller]
[Route("personnel")]
public class PersonnelController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<PersonnelController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([Bind("personnelId,contact,dateEntree,typeMainOeuvreIdPersonnel,nom,prenom,dateNaissance,email,trueDateEntree")] Personnel personnel){
	 	_context.Personnel.Add(personnel);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		
		ViewData["typeMainOeuvreIdPersonnel"] = await _context.TypeMainOeuvre.ToListAsync();
		
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit(int? id, [Bind("personnelId,contact,dateEntree,typeMainOeuvreIdPersonnel,nom,prenom,dateNaissance,email,trueDateEntree")] Personnel personnel){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.Personnel.Update(personnel);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Edit(int? id)
	{
		if (id == null)
		{
			return NotFound();
		}
		var personnel = await _context.Personnel.FirstOrDefaultAsync(m => m.personnelId == id);
		if (personnel == null)
		{
			return NotFound();
		}
		
		ViewData["typeMainOeuvreIdPersonnel"] = await _context.TypeMainOeuvre.ToListAsync();
		
		return View(personnel);
	}
	[HttpGet]
	public async Task<IActionResult> Delete(int? id){
	 	if (id == null)
		{
			return NotFound();
		}
		var personnel = await _context.Personnel.FirstOrDefaultAsync(m => m.personnelId == id);
		if (personnel == null)
		{
			return NotFound();
		}
		_context.Personnel.Remove(personnel);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.Personnel.ToListAsync());
	}
	public PersonnelController(RepositoryDbContext context) { _context = context; }

}
