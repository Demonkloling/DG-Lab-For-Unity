using UnityEngine;
using lyqbing.DGLAB;
using System.Collections.Generic;

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



	//��ȡ��Ϸ��Ӧ����
	public async void GetGameResponse()
	{
		GameResponse data = await DGLab.GetGameResponse();

		// ��ӡ����̫���ˣ����д��������������д�ˣ��Լ����ĵ���
		// https://github.com/hyperzlib/DG-Lab-Coyote-Game-Hub/blob/main/docs/api.md
		Debug.Log(data.strengthConfig.strength);//���ǿ��
		Debug.Log(data.gameConfig.strengthChangeInterval[0]);// ���ǿ�ȱ仯�������λ����
		Debug.Log(data.gameConfig.enableBChannel); // �Ƿ�����Bͨ��
	}



	//��ȡ �����б� 
	public async void GetPulseList()
	{
		List<PulseList> data = await DGLab.GetPulseList();

		string log = "";
        foreach (PulseList item in data)
        {
			log += "�� ID��" + item.id + " Name��" + item.name + "��";
        }

		Debug.Log(log);
	}



	//��ȡ��ǰ ����ID �� �б�
	public async void GetPulseID()
	{
		PulseId data = await DGLab.GetPulseID();

		string currentPulseId = data.currentPulseId;
		string pulseIdList = data.currentPulseId;

		foreach (string id in data.pulseId)
		{
			if (currentPulseId == id) return;
			pulseIdList += "," + id;
		}

		Debug.Log("��ǰ���ŵ�ID: " + currentPulseId + "��ǰ�����б�" + pulseIdList);
	}



	//��ȡǿ������ ��ִ JSON�б�
	public async void GetStrengthConfig()
	{
		StrengthConfig data = await DGLab.GetStrengthConfig();
		Debug.Log(" ��ǰ����ǿ�ȣ�" + data.strength + " ��ǰ���ǿ�ȣ�" + data.randomStrength);
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
}
