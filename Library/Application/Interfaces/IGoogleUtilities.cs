using Google.Authenticator;

namespace Application.Interfaces
{
	public interface IGoogleUtilities
	{
		public bool ValidateTwoFactorPIN(string accountSecretKey, string inputCode);
		public SetupCode GenerateTwoFactorAuthentication(int ID, string accountSecretKey);
	}
}
