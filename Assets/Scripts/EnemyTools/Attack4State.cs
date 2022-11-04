using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack4State : FSMState
{
    public Attack4State(StateType state, MonoBehaviour owner, FSMManager manager) : base(state, owner, manager)
    {
    }

    public override void OnEnter()
    {
        owner.GetComponent<Animator>().SetTrigger("ddd");
    }

    public override void OnUpdate()
    {
        if (!owner.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack04_SwordAndShiled"))
        {
            manager.ChangeState(StateType.idle);
        }
    }
}
