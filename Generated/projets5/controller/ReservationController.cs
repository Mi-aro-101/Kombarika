namespace projets5.controller;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projets5.repository.RepositoryDbContext;
using projets5.entity.Reservation;

[Controller]
[Route("reservation")]
public class ReservationController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<ReservationController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([] Reservation reservation){
	 	_context.reservation.Add(reservation);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		#foreignKey#
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit([] Reservation reservation){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.Reservation.Update(reservation);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Edit()
	{
		if (id == null)
		{
			return NotFound();
		}
		var #object# = await _context.?.FirstOrDefaultAsync(m => m.#primaryKeyField# == id);
		if (#object# == null)
		{
			return NotFound();
		}
		#foreignKey#
		return View(#object#);
	}
	[HttpGet]
	public async Task<IActionResult> Delete([] Reservation reservation){
	 	if (id == null)
		{
			return NotFound();
		}
		var reservation = await _context.Reservation.FirstOrDefaultAsync(m => m.#primaryKeyField# == id);
		if (reservation == null)
		{
			return NotFound();
		}
		_context.Reservation.Remove(reservation);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	[HttpGet]
	public async Task<IActionResult> Index(){
	 	return View(await _context.Reservation.ToListAsync());
	}
	public ReservationController(RepositoryDbContext context) { _context = context; }

}
