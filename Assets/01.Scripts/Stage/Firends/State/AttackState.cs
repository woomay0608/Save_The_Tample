using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
   
    public AttackState(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (stateMachine.friends.Target != null)
        {
            stateMachine.friends.meshAgent.SetDestination(stateMachine.friends.Target.transform.position);
            stateMachine.friends.transform.localEulerAngles = stateMachine.friends.Target.transform.position - stateMachine.friends.meshAgent.transform.position;
            if(stateMachine.friends.IsRange)
            {
                stateMachine.ChangeState(stateMachine.rangeAttackState);
            }
            else
            {
                stateMachine.ChangeState(stateMachine.meleeAttackState);
            }

        }
        else
        {
            stateMachine.ChangeState(stateMachine.idleState);
        }
    }

    public override void Exit() 
    {
        base.Exit();
        //stateMachine.ChangeState(stateMachine.idleState);
    }

    public override void Update()
    {
        base.Update();
        if (stateMachine.friends.Target == null)
        {
            stateMachine.ChangeState(stateMachine.chasingState);
        }
        else
        {
            Attack();
        }
    }

    public virtual void Attack()
    {
    }
}
