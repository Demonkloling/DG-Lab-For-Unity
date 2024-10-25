namespace lyqbing.DGLAB
{
	using System.Collections.Generic;
	using UnityEngine;

	/// <summary>
	/// ʵ�� DG-Lab-Coyote-Game-Hub API
	/// </summary>
	public class CoyoteApi
	{
		private static CoyoteApi _instance;
		private bool _DeLogIS = true;
		private string _CoyotreUrl = "http://127.0.0.1:8920/";
		private string _ApiUrl = "http://127.0.0.1:8920/api/v2/game/";
		private string _ClientId = "all";

		public static CoyoteApi Instance
		{
			get
			{
				_instance ??= new CoyoteApi();
				return _instance;
			}
		}

		#region ���÷�����/��������
		/// <summary>
		/// Coyote-Game-Hub ��������ַ
		/// </summary>
		public static string CoyotreUrl
		{
			get
			{
				return Instance._CoyotreUrl;
			}
			set
			{
				Instance._CoyotreUrl = "http://" + value;
				Instance._ApiUrl = "http://" + value + "/api/v2/game/";
			}
		}

		/// <summary>
		/// �ͻ���ID
		/// </summary>
		public static string ClientID
		{
			get
			{
				return Instance._ClientId;
			}
			set
			{
				Instance._ClientId = value;
			}
		}

		/// <summary>
		/// �Ƿ��������־
		/// </summary>
		public static bool DeLogIS
		{
			get
			{
				return Instance._DeLogIS;
			}
			set
			{
				Instance._DeLogIS = value;
			}
		}

		#endregion

		#region ��ȡ��Ӧ���� Api ��ַ

		/// <summary>
		/// һ������ API (��V2)
		/// </summary>
		public string FireApi
		{
			get
			{
				return _ApiUrl + ClientID + "/action/fire";
			}
		}

		/// <summary>
		/// ����/��ȡ ������Ϸǿ������ API (��V2)
		/// </summary>
		public string StrengthConfigApi
		{
			get
			{
				return _ApiUrl + ClientID + "/strength";
			}
		}

		/// <summary>
		/// ��ȡ�����б� API (���� ��V2 �ĵ������޷�����������䣡�˹��ܴ��������쳣״̬������)
		/// </summary>
		public string PulseListApi
		{
			get
			{
				return CoyotreUrl + ClientID + "/pulse_list";
			}
		}

		/// <summary>
		/// ����/��ȡ ��ǰ����ID API (��V2)
		/// </summary>
		public string PulseIdApi
		{
			get
			{
				return _ApiUrl + ClientID + "/pulse";
			}
		}

		/// <summary>
		/// ��ȡ��Ϸ��Ӧ���� API (��V2)
		/// </summary>
		public string GameResponseApi
		{
			get
			{
				return _ApiUrl + ClientID;
			}
		}

		#endregion
	}

	/*
	�������ڽ�����ִ���ݣ��ϴ����裩
	����UnityĬ�ϲ�֧�ָ߼�JSON���ã�������Ҫ�ֶ�ʵ�ֵ���
	��ʹ���Զ���⣬������ʵ�ֿ�ƽ̨����
	*/

	#region �����б����
	/// <summary>
	/// �����б��ִJSON
	/// </summary>
	[System.Serializable]
	public class PulseListJson
	{
		public int status;
		public string code;
		public List<PulseList> pulseList;
	}

	/// <summary>
	/// �����б������ļ�
	/// </summary>
	[System.Serializable]
	public class PulseList
	{
		[Tooltip("����ID")] public string id;
		[Tooltip("��������")] public string name;
	}
	#endregion

	#region ���������ļ�
	/// <summary>
	/// ���������ļ�
	/// </summary>
	[System.Serializable]
	public class PulseId
	{
		public int status;
		public string code;
		[Tooltip("��ǰ����ID")] public string currentPulseId;
		[Tooltip("��ǰ�����б�")] public string[] pulseId;
	}
	#endregion

	#region ǿ���������
	/// <summary>
	/// ǿ�����û�ִJSON
	/// </summary>
	[System.Serializable]
	public class StrengthConfigJson
	{
		public int status;
		public string code;
		public StrengthConfig strengthConfig;
	}

	/// <summary>
	/// ǿ�������ļ�
	/// </summary>
	[System.Serializable]
	public class StrengthConfig
	{
		[Tooltip("����ǿ��")] public int strength;
		[Tooltip("���ǿ��")] public int randomStrength;
	}
	#endregion

	#region ��Ӧ�������
	/// <summary>
	/// ��ǰ��������
	/// </summary>
	[System.Serializable]
	public class GameConfig
	{
		public int[] strengthChangeInterval;
		public bool enableBChannel;
		public float bChannelStrengthMultiplier;
		public string pulseId;
		public string pulseMode;
		public int pulseChangeInterval;
	}

	/// <summary>
	/// ��ǰ�û�����
	/// </summary>
	[System.Serializable]
	public class ClientStrength
	{
		public int strength;
		public int limit;
	}

	/// <summary>
	/// ��Ϸ��Ӧ���ݻ�ִ
	/// </summary>
	[System.Serializable]
	public class GameResponse
	{
		public int status;
		public string code;
		public StrengthConfig strengthConfig;
		public GameConfig gameConfig;
		public ClientStrength clientStrength;
		public string currentPulseId;
	}
	#endregion
}