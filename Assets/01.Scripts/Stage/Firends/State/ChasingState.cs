using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingState : BaseState
{

    float MoveCoolTime = 7f;
    
    public ChasingState(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateMachine.friends.meshAgent.isStopped = false;
        stateMachine.friends.meshAgent.speed = stateMachine.friends.Getfriends().Speed;
        
        StartAnimation("Run");
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation("Run");


    }


    public override void Update()
    {
        base.Update();

        if(stateMachine.friends.IsInRange)
        {
            stateMachine.ChangeState(stateMachine.attackState);
        }

        time += Time.deltaTime;
        if(time > MoveCoolTime) 
        {
            time -= MoveCoolTime;
            Debug.Log("Go");
            FindNewLocation();
        }

    }




    private void FindNewLocation()
    {

        NavMeshHit nav;

        Vector3 vector = new Vector3(Random.Range(-10f, 10f), stateMachine.friends.meshAgent.transform.position.y, Random.Range(-10f, 10f));
        if (NavMesh.SamplePosition(vector, out nav, 10f, NavMesh.AllAreas))
        {
            stateMachine.friends.meshAgent.SetDestination(nav.position);

        }
        else
        {

            stateMachine.friends.meshAgent.SetDestination(stateMachine.friends.meshAgent.transform.position);
        }
    }



}
