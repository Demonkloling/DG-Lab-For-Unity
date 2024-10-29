namespace lyqbing.DGLAB
{
	using System;
	using System.Net.Http;
	using System.Text;
	using System.Threading.Tasks;

	public static class FTPManager
	{
		/// <summary>
		/// Get����
		/// </summary>
		public static async Task<string> Get(string Url)
		{
			HttpRequestMessage request = new(HttpMethod.Get, Url);
			return await IsSuccessStatusCode(request);
		}

		/// <summary>
		/// POST����
		/// </summary>
		public static async Task<string> Post(string Url, string jsonParas)
		{
			HttpRequestMessage request = new(HttpMethod.Post, Url)
			{
				Content = new StringContent(jsonParas, Encoding.UTF8, "application/x-www-form-urlencoded")
			};

			return await IsSuccessStatusCode(request);
		}

		/// <summary>
		/// �����������ִ
		/// </summary>
		public static async Task<string> IsSuccessStatusCode(HttpRequestMessage request)
		{
			HttpClient httpClient = new();
			HttpResponseMessage response = await httpClient.SendAsync(request);

			if (response.IsSuccessStatusCode)
			{
				string responseBody = await response.Content.ReadAsStringAsync();
				return responseBody;
			}
			else
			{
				Console.WriteLine("��FTPManager������ʧ�ܣ�״̬��: " + response.StatusCode);
				return null;
			}
		}
	}
}