using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 消息中转中心
public class MessageCenter
{
    //管理类集合
    public static List<MonoBase> Managers = new List<MonoBase>();

    //发送消息
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
