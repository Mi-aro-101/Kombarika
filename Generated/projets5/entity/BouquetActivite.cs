namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("bouquet_activite")]
public class BouquetActivite {
	[ForeignKey("activite_id_bouquet_activite")]
	public int activiteIdBouquetActivite { get; set; }
	public Activite activite { get; set; }
	[ForeignKey("bouquet_id_bouquet_activite")]
	public int bouquetIdBouquetActivite { get; set; }
	public Bouquet bouquet { get; set; }


	public BouquetActivite(){}

}
