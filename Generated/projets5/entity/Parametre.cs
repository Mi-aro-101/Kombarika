namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("parametre")]
public class Parametre {
	[Key]
	[Column("parametre_id")]
	public int parametreId { get; set; }
	[Column("valeur")]
	public decimal valeur { get; set; }
	[Column("libelle")]
	public string libelle { get; set; }


	public Parametre(){}

}
