using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 状态机枚举
// 状态机枚举
public enum StateType
{
    idle,
    run,
    attack1,
    attack2,
    attack3,
    attack4,
}
// 状态机类，抽象类
public abstract class FSMState
{
    public StateType state;             // 当前状态
    public MonoBehaviour owner;         // 状态拥有者
    public FSMManager manager;          // 所属管理类

    public FSMState(StateType state, MonoBehaviour owner, FSMManager manager)
    {
        this.state = state;
        this.owner = owner; 
        this.manager = manager; 
    }

    // 状态初始化方法，抽象方法必须实现
    public abstract void OnEnter();

    // 状态更新方法
    public abstract void OnUpdate();
}
