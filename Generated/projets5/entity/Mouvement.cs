namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("mouvement")]
public class Mouvement {
	[ForeignKey("activite_id_mouvement")]
	Activite activite { get; set; }
	[Column("quantite_entree")]
	int quantiteEntree { get; set; }
	[Column("quantite_sortie")]
	int quantiteSortie { get; set; }
	[Column("date_heure_mouvement")]
	DateTime dateHeureMouvement { get; set; }
	[Key]
	[Column("mouvement_id")]
	int mouvementId { get; set; }


	public Mouvement(){}

}
