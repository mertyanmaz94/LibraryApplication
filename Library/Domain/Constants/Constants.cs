
namespace Domain.Constants
{
    public class Constants
    {
		//Değişkenlerin alabileceği değerlerin belli olduğu durumlarda programı daha okunabilir hale getirmek için enumlar kullanılır.
        //yeni bir değer eklemek istediğimizde database'e kayıt atmak yerine buradan ekleme yapabiliriz.
		public enum StatusCodes
        {
            Passive = 0,
            Active = 1
        }
    }
}
