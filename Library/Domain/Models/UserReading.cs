using Domain.Common;

namespace Domain.Models
{
    public class UserReading : ExtendedBaseModel
    {
        public int ReaderID {  get; set; }
        public int BookID {  get; set; }
		public DateTime ExpirationDate { get; set; }
		public virtual Reader Reader { get; set; }
    }
}
