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
		private readonly string _ApiUrl = "api/v2/game/";
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
		/// һ������ API
		/// </summary>
		public string FireApi => _CoyotreUrl + _ApiUrl + ClientID + "/action/fire";

		/// <summary>
		/// ����/��ȡ ������Ϸǿ������ API
		/// </summary>
		public string StrengthConfigApi => _CoyotreUrl + _ApiUrl + ClientID + "/strength";

		/// <summary>
		/// ��ȡ��ȡ���������õĲ����б� API
		/// </summary>
		public string PulseListApi => CoyotreUrl + "api/v2/pulse_list";

		/// <summary>
		/// ��ȡ�����Ĳ����б������ͻ����Զ��岨�� API
		/// </summary>
		public string AllPulseListApi => _CoyotreUrl + _ApiUrl + ClientID + "/pulse_list";

		/// <summary>
		/// ����/��ȡ ��ǰ����ID API
		/// </summary>
		public string PulseIdApi => _CoyotreUrl + _ApiUrl + ClientID + "/pulse";

		/// <summary>
		/// ��ȡ��Ϸ��Ӧ���� API
		/// </summary>
		public string GameResponseApi => _CoyotreUrl + _ApiUrl + ClientID;

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