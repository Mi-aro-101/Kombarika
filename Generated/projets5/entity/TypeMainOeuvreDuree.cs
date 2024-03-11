namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("type_main_oeuvre_duree")]
public class TypeMainOeuvreDuree {
	[ForeignKey("type_duree_id_main_oeuvre_duree")]
	public int typeDureeIdMainOeuvreDuree { get; set; }
	public TypeDuree typeDuree { get; set; }
	[Column("nb_main_oeuvre")]
	public int nbMainOeuvre { get; set; }
	[ForeignKey("type_main_oeuvre_id_main_oeuvre_duree")]
	public int typeMainOeuvreIdMainOeuvreDuree { get; set; }
	public TypeMainOeuvre typeMainOeuvre { get; set; }


	public TypeMainOeuvreDuree(){}

}
