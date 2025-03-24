using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
   
    public override void Enter()
    {
        base.Enter();
        stateMachine.friends.meshAgent.SetDestination(stateMachine.friends.Target.transform.position);
    }

    public override void Exit() 
    {
        base.Exit();
        stateMachine.ChangeState(stateMachine.idleState);
    }

    public override void Update()
    {
        base.Update();
        Attack();
    }

    private void Attack()
    {
        float Dis = Vector3.Distance(stateMachine.friends.meshAgent.transform.position, stateMachine.friends.Target.transform.position);
        if(Dis < stateMachine.friends.Getfriends().AttackRange)
        {
            float time = Time.deltaTime;
            if (stateMachine.friends.Getfriends().AttackCoolTime > time )
            {
                time -= stateMachine.friends.Getfriends().AttackCoolTime;
                stateMachine.friends.IsAttacking = true;
                StartAnimation("Attack");
            }
            else
            {
                stateMachine.friends.meshAgent.SetDestination(stateMachine.friends.Target.transform.position);
                stateMachine.friends.IsAttacking = false;
            }
            
        }
        else
        {
            if(stateMachine.friends.IsInRange)
            {
                stateMachine.friends.meshAgent.SetDestination(stateMachine.friends.Target.transform.position);
                stateMachine.friends.IsAttacking = false;
            }
            else
            {
                stateMachine.ChangeState(stateMachine.idleState);
                stateMachine.friends.IsAttacking = false;
            }
        }



    }
}
