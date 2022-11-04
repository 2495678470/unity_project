using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2State : FSMState
{
    public Attack2State(StateType state, MonoBehaviour owner, FSMManager manager) : base(state, owner, manager)
    {
    }

    public override void OnEnter()
    {
        owner.GetComponent<Animator>().SetTrigger("bbb");
    }

    public override void OnUpdate()
    {
        if (!owner.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack02_SwordAndShiled"))
        {
            manager.ChangeState(StateType.idle);
        }
    }
}
