using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��Ϣ��ת����
public class MessageCenter
{
    //�����༯��
    public static List<MonoBase> Managers = new List<MonoBase>();

    //������Ϣ
    public static void SendMessage(Message msg)
    {
        foreach (MonoBase mb in Managers)
        {
            mb.ReceiveMessage(msg);
        }
    }

    public static void SendMessage(byte type, int command, object content)
    {
        Message msg = new Message(type, command, content);
        SendMessage(msg);
    }
}
