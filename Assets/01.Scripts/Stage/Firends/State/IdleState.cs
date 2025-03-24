using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{

    public override void Enter()
    {
        base.Enter();
        if(stateMachine.friends == null)
        {
            Debug.Log("Friednsnull");
        }
        stateMachine.friends.meshAgent.isStopped = true;
        StartAnimation("Idle");
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.friends.meshAgent.isStopped = false;
        StopAnimation("Idle");
    }


    private IEnumerator WaittoChais()
    {
        yield return new WaitForSeconds(2f);
        stateMachine.ChangeState(stateMachine.chasingState);
    }

}
