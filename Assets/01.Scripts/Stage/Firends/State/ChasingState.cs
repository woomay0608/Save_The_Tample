using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingState : BaseState
{


    public override void Enter()
    {
        base.Enter();

        stateMachine.friends.meshAgent.isStopped = false;
        stateMachine.friends.meshAgent.speed = stateMachine.friends.Getfriends().Speed;
        StartCoroutine(WaitForSecond());

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

    }


    private IEnumerator WaitForSecond()
    {

        FindNewLocation();
        yield return new WaitForSeconds(5f);
        stateMachine.ChangeState(stateMachine.idleState);



    }

    private  void FindNewLocation()
    {
       
        NavMeshHit nav;

        Vector3 vector = Random.onUnitSphere * 10f;
       if(NavMesh.SamplePosition(vector, out nav, 10f, NavMesh.AllAreas)) 
        {
            stateMachine.friends.meshAgent.SetDestination(nav.position);
        }
       else
        {
            stateMachine.friends.meshAgent.SetDestination(stateMachine.friends.meshAgent.transform.position);
        }
    }



}
