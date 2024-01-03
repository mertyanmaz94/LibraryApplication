using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Book : ExtendedBaseModel
    {
        public string Name {  get; set; }
        public string Author {  get; set; }
        public string PictureUrl {  get; set; }
        public bool InTheLibrary {  get; set; }
        public int BookTypeID {  get; set; }

		[Column(TypeName = "varchar(36)")]
		public string UniqID { get; set; }
        public virtual UserReading UserReading { get; set; }
		public  virtual BookType BookType { get; set; }        
    }
}
