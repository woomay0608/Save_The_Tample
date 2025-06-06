using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : AttackState
{
    public MeleeAttackState(StateMachine stateMachine) : base(stateMachine)
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
    public override void Attack()
    {
        base.Attack();
        if (stateMachine.friends.Target != null)
        {
            float Dis = Vector3.Distance(stateMachine.friends.meshAgent.transform.position, stateMachine.friends.Target.transform.position);

            if (Dis < stateMachine.friends.Getfriends().AttackRange)
            {
                time += Time.deltaTime;
                if (stateMachine.friends.GetfriendsStat().AllAttackCoolTime < time)
                {
                    //Debug.Log("Attack");
                    stateMachine.friends.IsAttacking = true;
                    time -= stateMachine.friends.Getfriends().AttackCoolTime;
                    stateMachine.friends.meshAgent.isStopped = true;
                    StartAnimation("Attack");

                }
                else
                {
                    stateMachine.friends.meshAgent.SetDestination(stateMachine.friends.Target.transform.position);
                    stateMachine.friends.meshAgent.isStopped = false;
                    stateMachine.friends.IsAttacking = false;

                    StopAnimation("Attack");
                    StartAnimation("Run");
                    //Debug.Log("AttackTIme");
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
                    stateMachine.ChangeState(stateMachine.chasingState);
                }
            }
        }
        else
        {
            stateMachine.friends.IsInRange = false;
            stateMachine.friends.IsAttacking = false;
            stateMachine.ChangeState(stateMachine.chasingState);
        }
    }
    


}
