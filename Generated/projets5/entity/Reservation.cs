namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("reservation")]
public class Reservation {
	[Key]
	[Column("reservation_id")]
	public int reservationId { get; set; }
	[Column("nbs_personne")]
	public int nbsPersonne { get; set; }
	[Column("montant_total")]
	public decimal montantTotal { get; set; }
	[Column("date_heure_reservation")]
	public DateTime dateHeureReservation { get; set; }
	[ForeignKey("client_id_reservation")]
	public int clientIdReservation { get; set; }
	public Client client { get; set; }
	[ForeignKey("voyage_id_reservation")]
	public int voyageIdReservation { get; set; }
	public Voyage voyage { get; set; }


	public Reservation(){}

}
