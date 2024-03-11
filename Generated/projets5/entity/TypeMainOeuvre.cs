namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("type_main_oeuvre")]
public class TypeMainOeuvre {
	[Column("interval_annee_experience")]
	public int intervalAnneeExperience { get; set; }
	[Column("croissance_salaire")]
	public decimal croissanceSalaire { get; set; }
	[Key]
	[Column("type_main_oeuvre_id")]
	public int typeMainOeuvreId { get; set; }
	[Column("annee_experience_debut")]
	public int anneeExperienceDebut { get; set; }
	[Column("salaire")]
	public decimal salaire { get; set; }
	[Column("type")]
	public string type { get; set; }
	[Column("annee_experience_fin")]
	public int anneeExperienceFin { get; set; }


	public TypeMainOeuvre(){}

}
