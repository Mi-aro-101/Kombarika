namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("composition_voyage_bouquet")]
public class CompositionVoyageBouquet {
	[ForeignKey("voyage_id_composition_voyage_bouquet")]
	public int voyageIdCompositionVoyageBouquet { get; set; }
	public Voyage voyage { get; set; }
	[Column("nombre_fois")]
	public int nombreFois { get; set; }
	[ForeignKey("activite_id_composition_voyage_bouquet")]
	public int activiteIdCompositionVoyageBouquet { get; set; }
	public Activite activite { get; set; }
	[ForeignKey("type_duree_id_composition_voyage_bouquet")]
	public int typeDureeIdCompositionVoyageBouquet { get; set; }
	public TypeDuree typeDuree { get; set; }
	[ForeignKey("bouquet_id_composition_voyage_bouquet")]
	public int bouquetIdCompositionVoyageBouquet { get; set; }
	public Bouquet bouquet { get; set; }


	public CompositionVoyageBouquet(){}

}
