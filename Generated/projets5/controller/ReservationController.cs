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
	public ActionResult<Reservation> save([FromBody] Reservation reservation){
	 	_context.reservation.Add(reservation);
		_context.SaveChanges();
		return Ok();
	}
	[HttpPut]
	public ActionResult<Reservation> update([FromBody] Reservation reservation){
	 	var temp = reservation;
		_context.SaveChanges();
		return Ok();
	}
	[HttpDelete]
	public void delete([FromBody] Reservation reservation){
	 	_context.Reservation.Remove(reservation);
		_context.SaveChanges();	return Ok();
	}
	[HttpGet]
	public ActionResult<IEnumerable<Reservation>> findAll(){
	 	return Ok(_context.Reservation.ToList());
	}
	public ReservationController(RepositoryDbContext context) { _context = context; }

}
