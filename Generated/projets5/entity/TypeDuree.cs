namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("type_duree")]
public class TypeDuree {
	[Column("nom_type_duree")]
	public string nomTypeDuree { get; set; }
	[Column("prix_duree")]
	public int prixDuree { get; set; }
	[Key]
	[Column("type_duree_id")]
	public int typeDureeId { get; set; }
	[Column("nombre_jour")]
	public int nombreJour { get; set; }


	public TypeDuree(){}

}
