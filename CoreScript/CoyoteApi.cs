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
		private string _CoyotreUrl = "http://127.0.0.1:8920/api/game/";
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
				Instance._CoyotreUrl = "http://" + value + "/api/game/";
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
		public string FireApi
		{
			get
			{
				return CoyotreUrl + ClientID + "/fire";
			}
		}

		/// <summary>
		/// ����/��ȡ �����ļ� API
		/// </summary>
		public string StrengthConfigApi
		{
			get
			{
				return CoyotreUrl + ClientID + "/strength_config";
			}
		}

		/// <summary>
		/// ��ȡ��Ϸ��Ϣ API
		/// </summary>
		public string GetGameApi
		{
			get
			{
				return CoyotreUrl + ClientID;
			}
		}

		/// <summary>
		/// ��ȡ�����б� API
		/// </summary>
		public string PulseListApi
		{
			get
			{
				return CoyotreUrl + ClientID + "/pulse_list";
			}
		}

		/// <summary>
		/// ����/��ȡ ����ID API
		/// </summary>
		public string PulseIdApi
		{
			get
			{
				return CoyotreUrl + ClientID + "/pulse_id";
			}
		}

		#endregion
	}

	/*
	�������ڽ�����ִ���ݣ��ϴ����裩
	����UnityĬ�ϲ�֧�ָ߼�JSON���ã�������Ҫ�ֶ�ʵ�ֵ���
	��ʹ���Զ���⣬������ʵ�ֿ�ƽ̨����
	*/

	#region �����б�
	[System.Serializable] //�����ִJSON
	public class PulseListJson
	{
		public int status;
		public string code;
		public List<PulseList> pulseList;
	}

	[System.Serializable] //�����ļ��б�
	public class PulseList
	{
		[Tooltip("����ID")] public string id;
		[Tooltip("��������")] public string name;
	}
	#endregion

	#region ��ǰ����ID
	[System.Serializable]
	public class PulseId //��ǰ����ID
	{
		public int status;
		public string code;
		[Tooltip("��ǰ����ID")] public string currentPulseId;
		[Tooltip("����ID")] public string pulseId;
	}
	#endregion

	#region ǿ������
	[System.Serializable]
	public class StrengthConfigJson //ǿ�����û�ִJSON
	{
		public int status;
		public string code;
		public StrengthConfig strengthConfig;
	}

	[System.Serializable]
	public class StrengthConfig //ǿ������
	{
		[Tooltip("����ǿ��")] public int strength;
		[Tooltip("���ǿ��")] public int randomStrength;
		[Tooltip("��С������")] public int minInterval;
		[Tooltip("���������")] public int maxInterval;
	}
	#endregion
}