using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//��Ϣ������
/// <summary>
/// �˴�Ϊ���ܳ�Ϊ�����أ�ԭ����
/// 1.ManagerBase<T> : MonoBase where T : MonoBase
/// ���������˼̳е����������
/// 2.public static T Instance;
/// �����������͵ľ�̬����
/// 3.Instance = this as T;
/// awake()�����������ʱ�͵����ˣ��ڴ˴���ֵ�˾�̬����������֮�󲻻���ģ�����ֻ��Ψһ�ľ�̬������ͨ�����þ�̬���������ø������
/// </summary>
/// <typeparam name="T"></typeparam>
public class ManagerBase<T> : MonoBase where T : MonoBase
{
    public static T Instance;
    //�������Ϣ������
    public List<MonoBase> ReceiveList = new List<MonoBase>();
    //��ǰ��������յ���Ϣ����
    protected byte messageType;

    protected virtual void Awake()
    {
        Instance = this as T;
        //������Ϣ����
        messageType = SetMessageType();
        //���ù�������뵽��Ϣ���ĵ��б���
        MessageCenter.Managers.Add(Instance);
    }
    
    //����ʵ�֣����ع��������Ϣ����
    protected virtual byte SetMessageType()
    {
        return MessageType.Type_UI;
    }

    //ע����Ϣ����
    public void RegisterReceiver(MonoBase mb)
    {
        if (!ReceiveList.Contains(mb))
        {
            ReceiveList.Add(mb);
        }
    }

    //���յ�����Ϣ�����·ַ���Ϣ
    public override void ReceiveMessage(Message message)
    {
        base.ReceiveMessage(message);
        //������յ���Ϣ���Ͳ�ƥ�䣬�����·ַ���Ϣ
        if (message.Type != messageType)
        {
            return;
        }

        foreach (MonoBase mb in ReceiveList)
        {
            mb.ReceiveMessage(message);
        }
    }
}
