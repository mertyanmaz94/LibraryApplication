using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Domain.Models
{
	//Databasede verileri tuttuğumuz tablolara karşılık gelecek olan modelleri Domain katmanında tutarız.
	public class AdminUser
	{
		[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
		[Key]
		public int ID { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int Status { get; set; }
		public DateTime InsertionDate { get; set; }

		[Column(TypeName = "bit")]
		[DefaultValue(false)]
		public bool AuthenticatorFlag { get; set; }

		[Column(TypeName = "varchar(36)")]
		public string AccountSecretKey { get; set; }
	}
}
