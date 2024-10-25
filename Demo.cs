using UnityEngine;
using lyqbing.DGLAB;
using System.Collections.Generic;
using Mono.Cecil.Cil;

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
		GameResponse data = await DGLAB.GetGameResponse();

		// ��ӡ����̫���ˣ����д��������������д�ˣ��Լ����ĵ���
		// https://github.com/hyperzlib/DG-Lab-Coyote-Game-Hub/blob/main/docs/api.md
		Debug.Log(data.strengthConfig.strength);//���ǿ��
		Debug.Log(data.gameConfig.strengthChangeInterval[0]);// ���ǿ�ȱ仯�������λ����
		Debug.Log(data.gameConfig.enableBChannel); // �Ƿ�����Bͨ��
	}



	//��ȡ �����б� -- ���ش��󣺹ٷ�ԭ�� --
	public void GetPulseList()
	{
		//PulseListJson Data = await DGLAB.GetPulseList();
		Debug.Log("�ȴ��ٷ��޸�");
	}



	//��ȡ��ǰ ����ID �� �б�
	public async void GetPulseID()
	{
		PulseId data = await DGLAB.GetPulseID();

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
		StrengthConfig data = await DGLAB.GetStrengthConfig();
		Debug.Log(" ��ǰ����ǿ�ȣ�" + data.strength + " ��ǰ���ǿ�ȣ�" + data.randomStrength);
	}



	//һ������
	public void Fire() => DGLAB.Fire();



	//��������ID (2������)
	public void SetPulseID()
	{
		DGLAB.SetPulseID("ID");

		List<string> list = new()
		{
			"ID1",
			"ID2"
		};
		DGLAB.SetPulseID(list);
	}



	//ǿ������
	public void SetStrengthConfigAdd()
	{
		DGLAB.SetStrength.Add();
		DGLAB.SetStrength.Sub();
		DGLAB.SetStrength.Set();
		
		DGLAB.SetRandomStrength.Add();
		DGLAB.SetRandomStrength.Sub();
		DGLAB.SetRandomStrength.Set();
	}
}
