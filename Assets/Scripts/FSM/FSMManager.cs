using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// ×´Ì¬¹ÜÀíÆ÷
public class FSMManager
{
    public Dictionary<StateType, FSMState> stateList = new Dictionary<StateType, FSMState>();
    private StateType stateType = StateType.idle;

    public void ChangeState(StateType state)
    {
        stateType = state;
        stateList[stateType].OnEnter();
    }

    public void Update()
    {
        stateList[stateType].OnUpdate();
    }

}
