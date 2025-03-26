using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : BaseState
{

    float IdleTime = 5f;
    public IdleState(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.friends.meshAgent.isStopped = true;
        StartAnimation("Idle");
        //stateMachine.ChangeState(stateMachine.chasingState);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.friends.meshAgent.isStopped = false;
        StopAnimation("Idle");
    }

    public override void Update()
    {
        base.Update();
        time += Time.deltaTime;
        if(IdleTime < time)
        {
            time -= IdleTime;
            stateMachine.ChangeState(stateMachine.chasingState);
        }
    }




}
