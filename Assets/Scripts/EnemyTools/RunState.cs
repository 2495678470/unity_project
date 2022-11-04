using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : FSMState
{
    public RunState(StateType state, MonoBehaviour owner, FSMManager manager) : base(state, owner, manager)
    {
    }

    public override void OnEnter()
    {
        owner.GetComponent<Animator>().SetBool("IsRun", true);
    }

    public override void OnUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        if (dir != Vector3.zero)
        {
            owner.transform.rotation = Quaternion.LookRotation(dir);
            owner.transform.Translate(Vector3.forward * 3 * Time.deltaTime);
        }
        else
        {
            manager.ChangeState(StateType.idle);
        }
    }

}
