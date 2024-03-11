namespace projets5.entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("client")]
public class Client {
	[Column("sexe")]
	int sexe { get; set; }
	[Column("nom")]
	string nom { get; set; }
	[Column("prenom")]
	string prenom { get; set; }
	[Key]
	[Column("client_id")]
	int clientId { get; set; }


	public Client(){}

}
