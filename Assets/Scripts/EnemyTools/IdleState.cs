using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class IdleState : FSMState
{
    public IdleState(StateType state, MonoBehaviour owner, FSMManager manager) : base(state, owner, manager)
    {
    }

    public override void OnEnter()
    {
        owner.GetComponent<Animator>().SetBool("IsRun", false);
        
    }

    public override void OnUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        if (dir != Vector3.zero)
        {
            manager.ChangeState(StateType.run);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            manager.ChangeState(StateType.attack1);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            manager.ChangeState(StateType.attack2);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            manager.ChangeState(StateType.attack3);
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            manager.ChangeState(StateType.attack4);
        }
    }

}
