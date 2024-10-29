namespace lyqbing.DGLAB
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public static class DGLab
	{
		/// <summary>
		/// ��ȡ��Ϸ��Ӧ����
		/// </summary>S
		public static async Task<string> GetGameResponse()
		{
			string JsonPost = await FTPManager.Get(CoyoteApi.Instance.GameResponseApi);
			DeLog(JsonPost);
			return JsonPost;
		}

		#region ��ȡ�����б�
		/// <summary>
		/// ��ȡ��ȡ���������õĲ����б� API
		/// </summary>
		public static async Task<string> GetPulseList()
		{
			string JsonPost = await FTPManager.Get(CoyoteApi.Instance.PulseListApi);
			return PulseListFTP(JsonPost);
		}

		/// <summary>
		/// ��ȡ�����Ĳ����б������ͻ����Զ��岨�� API
		/// </summary>
		public static async Task<string> GetAllPulseList()
		{
			string JsonPost = await FTPManager.Get(CoyoteApi.Instance.AllPulseListApi);
			return PulseListFTP(JsonPost);
		}

		private static string PulseListFTP(string JsonPost)
		{
			DeLog(JsonPost);
			return JsonPost;
		}
		#endregion

		#region һ������
		/// <summary>
		/// һ������API
		/// </summary>
		/// <param name="strength">һ������ǿ�ȣ����40</param>
		/// <param name="time">һ������ʱ�䣬��λ�����룬Ĭ��Ϊ5000�����30000��30�룩</param>
		/// <param name="overrides">���һ������ʱ���Ƿ�����ʱ�䣬trueΪ����ʱ�䣬falseΪ����ʱ�䣬Ĭ��Ϊfalse</param>
		/// <param name="pulseId">һ������Ĳ���ID</param>
		public static void Fire(int strength, int time, bool overrides, string pulseId)
		{
			string JsonPost = "strength=" + strength + "&time=" + time + "&override" + overrides + "&pulseId=" + pulseId;
			FireFTP(JsonPost);
		}

		/// <summary>
		/// һ������API
		/// </summary>
		/// <param name="strength">һ������ǿ�ȣ����40</param>
		/// <param name="time">һ������ʱ�䣬��λ�����룬Ĭ��Ϊ5000�����30000��30�룩</param>
		/// <param name="overrides">���һ������ʱ���Ƿ�����ʱ�䣬trueΪ����ʱ�䣬falseΪ����ʱ�䣬Ĭ��Ϊfalse</param>
		public static void Fire(int strength = 20, int time = 5000, bool overrides = false)
		{
			string JsonPost = "strength=" + strength + "&time=" + time + "&override" + overrides;
			FireFTP(JsonPost);
		}

		private static async void FireFTP(string JsonPost)
		{
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
		public static async Task<string> GetPulseID()
		{
			string JsonPost = await FTPManager.Get(CoyoteApi.Instance.PulseIdApi);
			DeLog(JsonPost);
			return JsonPost;
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
			PulseFTP(JsonPost);
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

			PulseFTP(JsonPost);
		}

		private static async void PulseFTP(string JsonPost)
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
			public static void Add(int Add = 1)
			{
				string JsonPost = "strength.add=" + Add;
				StrengthFTP(JsonPost);
			}
			public static void Sub(int Sub = 1)
			{
				string JsonPost = "strength.sub=" + Sub;
				StrengthFTP(JsonPost);
			}
			public static void Set(int Set = 1)
			{
				string JsonPost = "strength.set=" + Set;
				StrengthFTP(JsonPost);
			}
		}

		/// <summary>
		/// ���������Ϸǿ������
		/// </summary>
		public static class SetRandomStrength
		{
			public static void Add(int Add = 1)
			{
				string JsonPost = "randomStrength.add=" + Add;
				StrengthFTP(JsonPost);
			}
			public static void Sub(int Sub = 1)
			{
				string JsonPost = "randomStrength.sub=" + Sub;
				StrengthFTP(JsonPost);
			}
			public static void Set(int Set = 1)
			{
				string JsonPost = "randomStrength.set=" + Set;
				StrengthFTP(JsonPost);
			}
		}

		/// <summary>
		/// ��ȡ��Ϸǿ����Ϣ
		/// </summary>
		public static async Task<string> GetStrengthConfig()
		{
			string JsonPost = await FTPManager.Get(CoyoteApi.Instance.StrengthConfigApi);
			DeLog(JsonPost);
			return JsonPost;
		}

		private static async void StrengthFTP(string JsonPost)
		{
			JsonPost = await FTPManager.Post(CoyoteApi.Instance.StrengthConfigApi, JsonPost);
			DeLog(JsonPost);
		}

		#endregion

		/// <summary>
		/// ������־
		/// </summary>
		/// <param name="JsonPost">��־����</param>
		private static void DeLog(string JsonPost)
		{
			if(CoyoteApi.DeLogIS)
			{
				Console.Write("��DGLAB��" + JsonPost);
			}
		}
	}
}