namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("composition_voyage_bouquet")]
public class CompositionVoyageBouquet {
	[ForeignKey("voyage_id_composition_voyage_bouquet")]
	Voyage voyage { get; set; }
	[Column("nombre_fois")]
	int nombreFois { get; set; }
	[ForeignKey("activite_id_composition_voyage_bouquet")]
	Activite activite { get; set; }
	[ForeignKey("type_duree_id_composition_voyage_bouquet")]
	TypeDuree typeDuree { get; set; }
	[ForeignKey("bouquet_id_composition_voyage_bouquet")]
	Bouquet bouquet { get; set; }


	public CompositionVoyageBouquet(){}

}
