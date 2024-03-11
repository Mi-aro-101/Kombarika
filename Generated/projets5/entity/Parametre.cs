namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("parametre")]
public class Parametre {
	[Key]
	[Column("parametre_id")]
	int parametreId { get; set; }
	[Column("valeur")]
	decimal valeur { get; set; }
	[Column("libelle")]
	string libelle { get; set; }


	public Parametre(){}

}
