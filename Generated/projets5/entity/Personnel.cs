namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("personnel")]
public class Personnel {
	[Key]
	[Column("personnel_id")]
	public int personnelId { get; set; }
	[Column("contact")]
	public string contact { get; set; }
	[Column("date_entree")]
	public DateOnly dateEntree { get; set; }
	[ForeignKey("type_main_oeuvre_id_personnel")]
	public int typeMainOeuvreIdPersonnel { get; set; }
	public TypeMainOeuvre typeMainOeuvre { get; set; }
	[Column("nom")]
	public string nom { get; set; }
	[Column("prenom")]
	public string prenom { get; set; }
	[Column("date_naissance")]
	public DateOnly dateNaissance { get; set; }
	[Column("email")]
	public string email { get; set; }
	[Column("true_date_entree")]
	public DateOnly trueDateEntree { get; set; }


	public Personnel(){}

}
