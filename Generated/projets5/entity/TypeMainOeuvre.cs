namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("type_main_oeuvre")]
public class TypeMainOeuvre {
	[Column("interval_annee_experience")]
	int intervalAnneeExperience { get; set; }
	[Column("croissance_salaire")]
	decimal croissanceSalaire { get; set; }
	[Key]
	[Column("type_main_oeuvre_id")]
	int typeMainOeuvreId { get; set; }
	[Column("annee_experience_debut")]
	int anneeExperienceDebut { get; set; }
	[Column("salaire")]
	decimal salaire { get; set; }
	[Column("type")]
	string type { get; set; }
	[Column("annee_experience_fin")]
	int anneeExperienceFin { get; set; }


	public TypeMainOeuvre(){}

}
