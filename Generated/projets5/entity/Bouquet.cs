namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("bouquet")]
public class Bouquet {
	[Key]
	[Column("bouquet_id")]
	int bouquetId { get; set; }
	[Column("nom_bouquet")]
	string nomBouquet { get; set; }
	[Column("heure_travail")]
	int heureTravail { get; set; }


	public Bouquet(){}

}
