using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class BookType : ExtendedBaseModel
    {
        public string Name {  get; set; }
    }
}
