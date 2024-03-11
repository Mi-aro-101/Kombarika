namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("reservation")]
public class Reservation {
	[Key]
	[Column("reservation_id")]
	int reservationId { get; set; }
	[Column("nbs_personne")]
	int nbsPersonne { get; set; }
	[Column("montant_total")]
	decimal montantTotal { get; set; }
	[Column("date_heure_reservation")]
	DateTime dateHeureReservation { get; set; }
	[ForeignKey("client_id_reservation")]
	Client client { get; set; }
	[ForeignKey("voyage_id_reservation")]
	Voyage voyage { get; set; }


	public Reservation(){}

}
