namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("bouquet")]
public class Bouquet {
	[Key]
	[Column("bouquet_id")]
	public int bouquetId { get; set; }
	[Column("nom_bouquet")]
	public string nomBouquet { get; set; }
	[Column("heure_travail")]
	public int heureTravail { get; set; }


	public Bouquet(){}

}
