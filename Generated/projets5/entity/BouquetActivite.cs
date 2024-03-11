namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("bouquet_activite")]
public class BouquetActivite {
	[ForeignKey("activite_id_bouquet_activite")]
	Activite activite { get; set; }
	[ForeignKey("bouquet_id_bouquet_activite")]
	Bouquet bouquet { get; set; }


	public BouquetActivite(){}

}
