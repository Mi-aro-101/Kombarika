namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("mouvement")]
public class Mouvement {
	[ForeignKey("activite_id_mouvement")]
	public int activiteIdMouvement { get; set; }
	public Activite activite { get; set; }
	[Column("quantite_entree")]
	public int quantiteEntree { get; set; }
	[Column("quantite_sortie")]
	public int quantiteSortie { get; set; }
	[Column("date_heure_mouvement")]
	public DateTime dateHeureMouvement { get; set; }
	[Key]
	[Column("mouvement_id")]
	public int mouvementId { get; set; }


	public Mouvement(){}

}
