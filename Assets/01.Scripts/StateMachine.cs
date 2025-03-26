using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IState
{
    public void Enter();
    public void Exit();

    public void Update();
}


public class StateMachine : MonoBehaviour
{
    public IState curState;
    public IdleState idleState;
    public ChasingState chasingState;
    public AttackState attackState;


    public Friends friends;



    private void Awake()
    {
        friends = GetComponent<Friends>();
        idleState = new IdleState(this);
        chasingState = new ChasingState(this);
        attackState = new AttackState(this);
    }


    public void StartSetstate(IState state)
    {
        curState = state;
        curState.Enter();
    }
    public void ChangeState(IState state)
    {
        if (curState != null)
        {
            curState.Exit();
            curState = state;
            state.Enter();
        }
        else { Debug.Log("CurrentIsnull"); }
    }

    public void Update()
    {
        curState?.Update();
    }


}
