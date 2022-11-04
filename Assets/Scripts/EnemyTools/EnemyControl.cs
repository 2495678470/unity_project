using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyControl : MonoBase
{

    private Animator anim;
    private FSMManager fsmManager;

    void Start()
    {
        anim = GetComponent<Animator>();
        fsmManager = new FSMManager();
        IdleState idleState = new IdleState(StateType.idle, this, fsmManager);
        RunState runState = new RunState(StateType.run, this, fsmManager);
        Attack1State attack1State = new Attack1State(StateType.attack1, this, fsmManager);
        Attack2State attack2State = new Attack2State(StateType.attack2, this, fsmManager);  
        Attack3State attack3State = new Attack3State(StateType.attack3, this, fsmManager);  
        Attack4State attack4State = new Attack4State(StateType.attack4, this, fsmManager);
        fsmManager.stateList.Add(StateType.idle, idleState);
        fsmManager.stateList.Add(StateType.run, runState);
        fsmManager.stateList.Add(StateType.attack1, attack1State);
        fsmManager.stateList.Add(StateType.attack2, attack2State);
        fsmManager.stateList.Add(StateType.attack3, attack3State);
        fsmManager.stateList.Add(StateType.attack4, attack4State);

        //Ä¬ÈÏÊÇÕ¾Á¢×´Ì¬
        fsmManager.ChangeState(StateType.idle);
    }

    // Update is called once per frame
    void Update()
    {
        fsmManager.Update();

    }


}
