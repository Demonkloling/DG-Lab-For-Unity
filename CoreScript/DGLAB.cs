namespace lyqbing.DGLAB
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using UnityEngine;

	public static class DGLAB
	{
		/// <summary>
		/// ��ȡ��Ϸ��Ӧ����
		/// </summary>
		public static async Task<GameResponse> GetGameResponse()
		{
			string JsonPost = await FTPManager.Get(CoyoteApi.Instance.GameResponseApi);
			DeLog(JsonPost);
			return JsonUtility.FromJson<GameResponse>(JsonPost);
		}

		/// <summary>
		/// ��ȡ�����б� (�����쳣״̬)
		/// </summary>
		public static async Task<PulseListJson> GetPulseList()
		{
			string JsonPost = await FTPManager.Get(CoyoteApi.Instance.PulseListApi);
			DeLog(JsonPost);
			return JsonUtility.FromJson<PulseListJson>(JsonPost);
		}

		#region һ������
		/// <summary>
		/// һ������API
		/// </summary>
		/// <param name="strength">һ������ǿ�ȣ����40</param>
		/// <param name="time">һ������ʱ�䣬��λ�����룬Ĭ��Ϊ5000�����30000��30�룩</param>
		/// <param name="overrides">���һ������ʱ���Ƿ�����ʱ�䣬trueΪ����ʱ�䣬falseΪ����ʱ�䣬Ĭ��Ϊfalse</param>
		/// <param name="pulseId">һ������Ĳ���ID</param>
		public static async void Fire(int strength = 20, int time = 5000, bool overrides = false, string pulseId = "d6f83af0")
		{
			string JsonPost = "strength=" + strength + "&time=" + time + "&override" + overrides + "&pulseId=" + pulseId;
			JsonPost = await FTPManager.Post(CoyoteApi.Instance.FireApi, JsonPost);
			DeLog(JsonPost);
		}
		#endregion

		#region ��ȡ��Ϸ��ǰ����ID
		/// <summary>
		/// ��ȡ��Ϸ��ǰ����ID
		/// ע�⣺��ٷ��ĵ���ͬ���ĵ��н���ʾ pulseId (�б�) �������� currentPulseId (��ǰ)��
		/// ��ˣ���Ҫ��ȡ��ǰ����ID�����ȡ currentPulseId ���� pulseId Ϊ�գ����Ϊ��һ����
		/// </summary>
		/// <returns></returns>
		public static async Task<PulseId> GetPulseID()
		{
			string JsonPost = await FTPManager.Get(CoyoteApi.Instance.PulseIdApi);
			DeLog(JsonPost);
			return JsonUtility.FromJson<PulseId>(JsonPost);
		}
		#endregion

		#region ������Ϸ��ǰ����ID
		/// <summary>
		/// ������Ϸ��ǰ����ID
		/// </summary>
		/// <param name="pulseId">����ID</param>
		public static void SetPulseID(string pulseIds)
		{
			string JsonPost = "pulseId=" + pulseIds;

			PulseID(JsonPost);
		}

		/// <summary>
		/// ������Ϸ��ǰ����List
		/// </summary>
		/// <param name="pulseIds">����List</param>
		public static void SetPulseID(List<string> pulseIds)
		{
			string JsonPost = "";
			foreach (string id in pulseIds)
			{
				JsonPost += "pulseId[]=" + id + "&";
			}

			PulseID(JsonPost);
		}

		private static async void PulseID(string JsonPost)
		{
			JsonPost = await FTPManager.Post(CoyoteApi.Instance.PulseIdApi, JsonPost);
			DeLog(JsonPost);
		}
		#endregion

		#region ��Ϸǿ���������
		/// <summary>
		/// ���û�����Ϸǿ������
		/// </summary>
		public static class SetStrength
		{
			public static async void Add(int Add = 1)
			{
				string JsonPost = "strength.add=" + Add;
				JsonPost = await FTPManager.Post(CoyoteApi.Instance.StrengthConfigApi, JsonPost);
				DeLog(JsonPost);
			}
			public static async void Sub(int Sub = 1)
			{
				string JsonPost = "strength.sub=" + Sub;
				JsonPost = await FTPManager.Post(CoyoteApi.Instance.StrengthConfigApi, JsonPost);
				DeLog(JsonPost);
			}
			public static async void Set(int Set = 1)
			{
				string JsonPost = "strength.set=" + Set;
				JsonPost = await FTPManager.Post(CoyoteApi.Instance.StrengthConfigApi, JsonPost);
				DeLog(JsonPost);
			}
		}

		/// <summary>
		/// ���������Ϸǿ������
		/// </summary>
		public static class SetRandomStrength
		{
			public static async void Add(int Add = 1)
			{
				string JsonPost = "randomStrength.add=" + Add;
				JsonPost = await FTPManager.Post(CoyoteApi.Instance.StrengthConfigApi, JsonPost);
				DeLog(JsonPost);
			}
			public static async void Sub(int Sub = 1)
			{
				string JsonPost = "randomStrength.sub=" + Sub;
				JsonPost = await FTPManager.Post(CoyoteApi.Instance.StrengthConfigApi, JsonPost);
				DeLog(JsonPost);
			}
			public static async void Set(int Set = 1)
			{
				string JsonPost = "randomStrength.set=" + Set;
				JsonPost = await FTPManager.Post(CoyoteApi.Instance.StrengthConfigApi, JsonPost);
				DeLog(JsonPost);
			}
		}

		/// <summary>
		/// ��ȡ��Ϸǿ����Ϣ
		/// </summary>
		public static async Task<StrengthConfig> GetStrengthConfig()
		{
			string JsonPost = await FTPManager.Get(CoyoteApi.Instance.StrengthConfigApi);
			DeLog(JsonPost);
			return JsonUtility.FromJson<StrengthConfigJson>(JsonPost).strengthConfig;
		}

		#endregion

		private static void DeLog(string JsonPost)
		{
			if(CoyoteApi.DeLogIS)
			{
				Debug.Log("��DGLAB��" + JsonPost);
			}
		}
	}
}