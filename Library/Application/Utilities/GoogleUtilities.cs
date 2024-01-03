using Application.ConfigModels;
using Application.Interfaces;
using Google.Authenticator;

namespace Application.Utilities
{
	//Google Authenticator yapısını kuruduğumuz servis
	public class GoogleUtilities(IHttpUtilities httpUtilities, ConfigModel configuration) : IGoogleUtilities
	{
		private readonly IHttpUtilities httpUtilities = httpUtilities;
		private readonly ConfigModel configuration = configuration;

		public bool ValidateTwoFactorPIN(string accountSecretKey, string inputCode)
		{
			bool result = false;
			TwoFactorAuthenticator twoFactor = null;
			twoFactor = new TwoFactorAuthenticator();
			result = twoFactor.ValidateTwoFactorPIN(accountSecretKey, inputCode);
			return result;
		}

		public SetupCode GenerateTwoFactorAuthentication(int ID, string accountSecretKey)
		{
			SetupCode setupCode = null;
			TwoFactorAuthenticator twoFactor = null;
			twoFactor = new TwoFactorAuthenticator();
			setupCode = twoFactor.GenerateSetupCode("Library Uygulaması", ID.ToString(), accountSecretKey, false, 3);
			return setupCode;
		}
	}
}
