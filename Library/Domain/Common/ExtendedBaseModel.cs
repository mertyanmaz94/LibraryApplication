using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Domain.Common
{
    // Tablolarda ortak olarak bulunun kolonların tutulduğu ana sınıf
    public class ExtendedBaseModel
    {
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "datetime"), DefaultValue("getdate()")]
        public DateTime InsertionDate { get; set; }
        [Column(TypeName = "datetime"), DefaultValue("getdate()")]
        public DateTime UpdateDate { get; set; }
        [Column(TypeName = "int"), DefaultValue(1)]
        public int Status { get; set; }
    }
}
