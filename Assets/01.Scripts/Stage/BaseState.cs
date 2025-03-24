using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : MonoBehaviour, IState
{

    protected StateMachine stateMachine;
    private void Awake()
    {
        stateMachine = new StateMachine();
    }
    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void Update()
    {
        if (stateMachine.friends == null)
        {
            Debug.Log("Friednsnull");
        }
        if (stateMachine.friends.IsInRange)
        {
            stateMachine.ChangeState(stateMachine.attackState);
        }

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
