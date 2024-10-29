using lyqbing.DGLAB;
using System.Collections.Generic;
using System;

/*
 ���㿪���� Unity��Ϸ ���ӵ�����
BY.LYQBING��Q 3041329025��(Ⱥ 928175340)

���������ã�DG-Lab-Coyote-Game-Hub
https://github.com/hyperzlib/DG-Lab-Coyote-Game-Hub
 */

public class Demo
{
	//�����������
	public void Start()
	{
		CoyoteApi.CoyotreUrl = "127.0.0.1:8920";		//���÷�������ַ (Ĭ��127.0.0.1:8920) (Ĭ����������)
		CoyoteApi.ClientID = "all";						//���ÿ����豸ID Ĭ�Ͽ���ȫ���豸 (Ĭ����������)
		CoyoteApi.DeLogIS = true;						//�Ƿ���������־ (Ĭ��true) (Ĭ����������)
	}

	//һ������
	public void Fire() => DGLab.Fire();



	//��������ID (2������)
	public void SetPulseID()
	{
		DGLab.SetPulseID("ID");

		List<string> list = new()
		{
			"ID1",
			"ID2"
		};
		DGLab.SetPulseID(list);
	}



	//ǿ������
	public void SetStrengthConfigAdd()
	{
		DGLab.SetStrength.Add();
		DGLab.SetStrength.Sub();
		DGLab.SetStrength.Set();

		DGLab.SetRandomStrength.Add();
		DGLab.SetRandomStrength.Sub();
		DGLab.SetRandomStrength.Set();
	}



	#region �������������ܻ�û�ִJson����Ҫ����������ʹ�õ�����Json���н��� (������DGLab�ű��н��н���)
	//��ȡ��Ϸ��Ӧ����
	public async void GetGameResponse()
	{
		string data = await DGLab.GetGameResponse();
		Console.Write(data);
	}



	//��ȡ ������ �����б�
	public async void GetPulseList()
	{
		string data = await DGLab.GetPulseList();
		Console.Write(data);
	}



	//��ȡ ���� �����б� (�����ͻ���)
	public async void GetGamePulseList()
	{
		string data = await DGLab.GetAllPulseList();
		Console.Write(data);
	}



	//��ȡ��ǰ ����ID �� �б�
	public async void GetPulseID()
	{
		string data = await DGLab.GetPulseID();
		Console.Write(data);
	}



	//��ȡǿ������ ��ִ JSON�б�
	public async void GetStrengthConfig()
	{
		string data = await DGLab.GetStrengthConfig();
		Console.Write(data);
	}

	#endregion
}
