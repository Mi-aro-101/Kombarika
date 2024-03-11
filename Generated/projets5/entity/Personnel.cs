namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("personnel")]
public class Personnel {
	[Key]
	[Column("personnel_id")]
	int personnelId { get; set; }
	[Column("contact")]
	string contact { get; set; }
	[Column("date_entree")]
	DateOnly dateEntree { get; set; }
	[ForeignKey("type_main_oeuvre_id_personnel")]
	TypeMainOeuvre typeMainOeuvre { get; set; }
	[Column("nom")]
	string nom { get; set; }
	[Column("prenom")]
	string prenom { get; set; }
	[Column("date_naissance")]
	DateOnly dateNaissance { get; set; }
	[Column("email")]
	string email { get; set; }
	[Column("true_date_entree")]
	DateOnly trueDateEntree { get; set; }


	public Personnel(){}

}
