using UnityEngine;
using lyqbing.DGLAB;
using UnityEngine.UI; //ʹ�� DGLAB �����ռ�

/*
 ���㿪���� Unity��Ϸ ���ӵ�����
BY.LYQBING��Q 3041329025��(Ⱥ 928175340)

���������ã�DG-Lab-Coyote-Game-Hub
https://github.com/hyperzlib/DG-Lab-Coyote-Game-Hub
 */

public class Demo : MonoBehaviour
{
	public string CoyotreUrl = "127.0.0.1:8920";
	public string ClientID = "all";

	public int strength = 1;
	public string ID = "null";
	public int time = 1000;


	#region �ͻ������� (Ĭ����������)
	//���÷�������ַ (Ĭ��127.0.0.1:8920) (Ĭ����������)
	public void SetCoyotreUrl() => CoyoteApi.CoyotreUrl = CoyotreUrl;

	//���ÿ����豸ID Ĭ�Ͽ���ȫ���豸 (Ĭ����������)
	public void SetClientID() => CoyoteApi.ClientID = ClientID;

	//�Ƿ���������־ (Ĭ��true) (Ĭ����������)
	public void DeLogIS() => CoyoteApi.DeLogIS = !CoyoteApi.DeLogIS;
	#endregion

	#region ��ȡ �����б�
	public async void GetPulseList()
	{
		//��ȡ�����б� ��ִ JSON�б�
		PulseListJson Data = await DGLAB.GetPulseList();
		Debug.Log("(�������һ��) ����ID��" + Data.pulseList[0].id + " �������ƣ�" + Data.pulseList[0].name);
	}

	public async void GetPulseID()
	{
		//��ȡ��ǰ����ID ��ִ JSON�б�
		PulseId data = await DGLAB.GetPulseID();
		Debug.Log("��ǰ����ID(pulseId): " + data.pulseId + " ��ǰ����ID(currentPulseId): " + data.currentPulseId);
	}
	#endregion

	#region ��ȡ ǿ������
	public async void GetStrengthConfig()
	{
		//��ȡǿ������ ��ִ JSON�б�
		StrengthConfigJson data = await DGLAB.GetStrengthConfig();
		Debug.Log(" ��ǰ����ǿ�ȣ�" + data.strengthConfig.strength + " ��ǰ���ǿ�ȣ�" + data.strengthConfig.randomStrength);
	}
	#endregion

	#region һ������
	//һ������(ǿ��,ʱ��) (����Ĭ��Ϊ1,1000)
	public void Fire() => DGLAB.Fire(strength, time);
	#endregion

	#region ��������
	//��������ID(ID)
	public void SetPulseID(string ID) => DGLAB.SetPulseID(ID);
	#endregion

	#region ����ǿ��
	//�� ����ǿ��(ǿ��) (����Ĭ��Ϊ1)
	public void SetStrengthConfigAdd() => DGLAB.SetStrength.Add(strength);


	//�� ����ǿ��(ǿ��) (����Ĭ��Ϊ1)
	public void SetStrengthConfigSub() => DGLAB.SetStrength.Sub(strength);

	
	//�� ����ǿ��(ǿ��) (����Ĭ��Ϊ1)
	public void SetStrengthConfigSet() => DGLAB.SetStrength.Set(strength);
	#endregion

	#region ���ǿ��
	//�� ���ǿ��(ǿ��) (����Ĭ��Ϊ1)
	public void SetRandomStrengthConfigAdd() => DGLAB.SetRandomStrength.Add(strength);


	//�� ���ǿ��(ǿ��) (����Ĭ��Ϊ1)
	public void SetRandomStrengthConfigSub() => DGLAB.SetRandomStrength.Sub(strength);


	//�� ���ǿ��(ǿ��) (����Ĭ��Ϊ1)
	public void SetRandomStrengthConfigSet() => DGLAB.SetRandomStrength.Set(strength);
	#endregion

	#region ������
	//������С������(��ֵ)
	public void SetIntervalMin() => DGLAB.SetInterval.Min(strength);

	
	//�������������(��ֵ)
	public void SetIntervalMax() => DGLAB.SetInterval.Max(strength);
	#endregion
}
