using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���ա�������Ϣ����
public class MonoBase : MonoBehaviour
{

    public void SendCustomMessage(Message message)
    {
        MessageCenter.SendMessage(message);
    }

    public void SendCustomMessage(byte type, int command, object content)
    {
        Message msg = new Message(type, command, content);
        SendCustomMessage(msg);
    }

    public virtual void ReceiveMessage(Message message)
    {

    }
}
