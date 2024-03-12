namespace projets5.controller;

using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projets5.repository.RepositoryDbContext;
using Microsoft.EntityFrameworkCore;
using projets5.entity.Reservation;

[Controller]
[Route("reservation")]
public class ReservationController : Controller {
	private readonly RepositoryDbContext _context;
	private readonly ILogger<ReservationController> _logger;

	[HttpPost]
	public async Task<IActionResult> Create([Bind("reservationId,nbsPersonne,montantTotal,dateHeureReservation,clientIdReservation,voyageIdReservation")] Reservation reservation){
	 	_context.Reservation.Add(reservation);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Create()
	{
		
		ViewData["clientIdReservation"] = await _context.Client.ToListAsync();
		
		ViewData["voyageIdReservation"] = await _context.Voyage.ToListAsync();
		
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Edit(int? id, [Bind("reservationId,nbsPersonne,montantTotal,dateHeureReservation,clientIdReservation,voyageIdReservation")] Reservation reservation){
	 	if (id == null)
		{
			return NotFound();
		}
		_context.Reservation.Update(reservation);
		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}
	public IActionResult Edit(int? id)
	{
		if (id == null)
		{
			return NotFound();
		}
		var reservation = await _context.Reservation.FirstOrDefaultAsync(m => m.reservationId == id);
		if (reservation == null)
		{
			return NotFound();
		}
		
		ViewData["clientIdReservation"] = await _context.Client.ToListAsync();
		
		ViewData["voyageIdReservation"] = await _context.Voyage.ToListAsync();
		
		return View(reservation);
	}
	[HttpGet]
	public async Task<IActionResult> Delete(int? id){
	 	if (id == null)
		{
			return NotFound();
		}
		var reservation = await _context.Reservation.FirstOrDefaultAsync(m => m.reservationId == id);
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
