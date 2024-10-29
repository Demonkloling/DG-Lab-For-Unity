namespace lyqbing.DGLAB
{
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
}