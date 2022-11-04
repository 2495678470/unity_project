using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack3State : FSMState
{
    public Attack3State(StateType state, MonoBehaviour owner, FSMManager manager) : base(state, owner, manager)
    {
    }

    public override void OnEnter()
    {
        owner.GetComponent<Animator>().SetTrigger("ccc");
    }

    public override void OnUpdate()
    {
        if (!owner.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack03_SwordAndShiled"))
        {
            manager.ChangeState(StateType.idle);
        }
    }
}
