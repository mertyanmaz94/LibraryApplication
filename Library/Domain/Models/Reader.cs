using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Reader : ExtendedBaseModel
    {
        public string ReaderName { get; set; }
        public string ReaderSurname { get; set; }
        public string PhoneNumber { get; set; }    
    }
}
