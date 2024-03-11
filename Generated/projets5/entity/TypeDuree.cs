namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("type_duree")]
public class TypeDuree {
	[Column("nom_type_duree")]
	string nomTypeDuree { get; set; }
	[Column("prix_duree")]
	int prixDuree { get; set; }
	[Key]
	[Column("type_duree_id")]
	int typeDureeId { get; set; }
	[Column("nombre_jour")]
	int nombreJour { get; set; }


	public TypeDuree(){}

}
