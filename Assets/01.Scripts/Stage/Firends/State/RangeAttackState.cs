using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackState : AttackState
{
    public RangeAttackState(StateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        //base.Enter();
    }
    public override void Exit() 
    { 
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
 
    }
    public override void Attack()
    {
        base.Attack();

        float Dis = Vector3.Distance(stateMachine.friends.meshAgent.transform.position, stateMachine.friends.Target.transform.position);

        if (Dis < stateMachine.friends.Getfriends().AttackRange)
        {
            time += Time.deltaTime;
            if (stateMachine.friends.GetfriendsStat().AllAttackCoolTime < time)
            {
                //Debug.Log("Attack");
                stateMachine.friends.IsAttacking = true;
                time -= stateMachine.friends.GetfriendsStat().AllAttackCoolTime;
                stateMachine.friends.meshAgent.isStopped = true;
                StartAnimation("RangeAttack");
                stateMachine.friends.BulletShoot();

            }
            else
            {
                stateMachine.friends.IsAttacking = false;
                stateMachine.friends.meshAgent.isStopped = true;
            }

        }
        else
        {
            if (stateMachine.friends.IsInRange)
            {
                stateMachine.friends.meshAgent.SetDestination(stateMachine.friends.Target.transform.position);
            }
            else
            {
                stateMachine.ChangeState(stateMachine.idleState);
            }
        }
    }
      



}
