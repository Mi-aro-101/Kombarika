using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcTest_Ef.Models;

[Table("matiere_premiere")]
public class MatierePremiere
{

    public MatierePremiere(){}

    [Key]
    [Column("id_matiere_premiere")]
    public int IdMatierePremiere{get; set;}
    [Column("designation")]
    public required string Designation {get; set;}
    [Column("prix_unitaire")]
    public double PrixUnitaire {get; set;}
}