using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1State : FSMState
{
    public Attack1State(StateType state, MonoBehaviour owner, FSMManager manager) : base(state, owner, manager)
    {
    }

    public override void OnEnter()
    {
        owner.GetComponent<Animator>().SetTrigger("aaa");
    }

    public override void OnUpdate()
    {
        if (!owner.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack01_SwordAndShiled"))
        {
            manager.ChangeState(StateType.idle);
        }
    }

}
