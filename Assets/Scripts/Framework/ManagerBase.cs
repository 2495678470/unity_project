using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//消息管理器
/// <summary>
/// 此处为何能成为单例呢，原因是
/// 1.ManagerBase<T> : MonoBase where T : MonoBase
/// 这里引入了继承的子类的类型
/// 2.public static T Instance;
/// 定义子类类型的静态变量
/// 3.Instance = this as T;
/// awake()方法是类加载时就调用了，在此处赋值了静态变量，并且之后不会更改，所以只有唯一的静态变量，通过调用静态变量来调用该类对象
/// </summary>
/// <typeparam name="T"></typeparam>
public class ManagerBase<T> : MonoBase where T : MonoBase
{
    public static T Instance;
    //管理的消息接受者
    public List<MonoBase> ReceiveList = new List<MonoBase>();
    //当前管理类接收的消息类型
    protected byte messageType;

    protected virtual void Awake()
    {
        Instance = this as T;
        //设置消息类型
        messageType = SetMessageType();
        //将该管理类插入到消息中心的列表中
        MessageCenter.Managers.Add(Instance);
    }
    
    //必须实现，返回管理类的消息类型
    protected virtual byte SetMessageType()
    {
        return MessageType.Type_UI;
    }

    //注册消息监听
    public void RegisterReceiver(MonoBase mb)
    {
        if (!ReceiveList.Contains(mb))
        {
            ReceiveList.Add(mb);
        }
    }

    //接收到了消息，向下分发消息
    public override void ReceiveMessage(Message message)
    {
        base.ReceiveMessage(message);
        //如果接收的消息类型不匹配，则不向下分发消息
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
