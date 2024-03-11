namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("voyage")]
public class Voyage {
	[Column("nom_voyage")]
	public string nomVoyage { get; set; }
	[Key]
	[Column("voyage_id")]
	public int voyageId { get; set; }
	[Column("prix_voyage")]
	public decimal prixVoyage { get; set; }


	public Voyage(){}

}
