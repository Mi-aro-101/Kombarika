namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("voyage")]
public class Voyage {
	[Column("nom_voyage")]
	string nomVoyage { get; set; }
	[Key]
	[Column("voyage_id")]
	int voyageId { get; set; }
	[Column("prix_voyage")]
	decimal prixVoyage { get; set; }


	public Voyage(){}

}
