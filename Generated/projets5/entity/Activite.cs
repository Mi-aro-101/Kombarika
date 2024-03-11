namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("activite")]
public class Activite {
	[Key]
	[Column("activite_id")]
	public int activiteId { get; set; }
	[Column("nom_activite")]
	public string nomActivite { get; set; }
	[Column("prix_unitaire")]
	public decimal prixUnitaire { get; set; }


	public Activite(){}

}
