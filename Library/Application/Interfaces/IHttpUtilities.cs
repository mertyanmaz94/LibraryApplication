using RestSharp;

namespace Application.Interfaces
{
	public interface IHttpUtilities
	{
		RestResponse ExecuteHttpRequest(string endpoint, string requestBody, Method method, DataFormat dataFormat, Dictionary<string, string> headers = null);
	}
}
