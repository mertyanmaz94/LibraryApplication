using Application.Interfaces;
using RestSharp;

namespace Application.Utilities
{
	//bir endpointe request atıp response almamızı sağlayan rest servise. Google Authanticatore ulaşmak için ihtiyaç duyuluyor.
	public class HttpUtilities : IHttpUtilities
	{
		public RestResponse ExecuteHttpRequest(string endpoint, string requestBody, Method method, DataFormat dataFormat, Dictionary<string, string> headers = null)
		{
			RestResponse restResponse = null;
			var request = new RestRequest("", method);
			var client = new RestClient(endpoint);
			if ("" + requestBody != "")
			{
				request.AddBody(requestBody, "application/json");
			}
			if (headers != null)
			{
				foreach (KeyValuePair<string, string> header in headers)
				{
					request.AddHeader(header.Key, header.Value);
				}
			}
			restResponse = client.ExecuteAsync(request).GetAwaiter().GetResult();
			return restResponse;
		}
	}
}
