namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("client")]
public class Client {
	[Column("sexe")]
	public int sexe { get; set; }
	[Column("nom")]
	public string nom { get; set; }
	[Column("prenom")]
	public string prenom { get; set; }
	[Key]
	[Column("client_id")]
	public int clientId { get; set; }


	public Client(){}

}
