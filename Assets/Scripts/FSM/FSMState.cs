using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ״̬��ö��
// ״̬��ö��
public enum StateType
{
    idle,
    run,
    attack1,
    attack2,
    attack3,
    attack4,
}
// ״̬���࣬������
public abstract class FSMState
{
    public StateType state;             // ��ǰ״̬
    public MonoBehaviour owner;         // ״̬ӵ����
    public FSMManager manager;          // ����������

    public FSMState(StateType state, MonoBehaviour owner, FSMManager manager)
    {
        this.state = state;
        this.owner = owner; 
        this.manager = manager; 
    }

    // ״̬��ʼ�����������󷽷�����ʵ��
    public abstract void OnEnter();

    // ״̬���·���
    public abstract void OnUpdate();
}
