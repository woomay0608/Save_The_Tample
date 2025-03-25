using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : IState
{

    protected StateMachine stateMachine;
    protected float time;

    public BaseState(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }


    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void Update()
    {
        //if (stateMachine.friends.IsInRange)
        //{
        //    Debug.Log("AttackOn");
        //    stateMachine.ChangeState(stateMachine.attackState);
        //}

    }




    protected void StartAnimation(string name)
    {
        stateMachine.friends.animator.SetBool(name, true);
    }

    protected void StopAnimation(string name)
    {
        stateMachine.friends.animator.SetBool(name, false);
    }

}
