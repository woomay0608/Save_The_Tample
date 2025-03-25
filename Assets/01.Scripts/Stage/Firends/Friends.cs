
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;


public class Friends : MonoBehaviour
{
    public  Animator animator;
    public NavMeshAgent meshAgent;
    public GameObject Target;
    public bool IsInRange =false;
    public bool IsAttacking = false;
    private StateMachine stateMachine;
   
    [SerializeField]private FriendSo FriendsSo;
    
    private void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
        animator = GetComponentInChildren<Animator>();
        meshAgent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        stateMachine.StartSetstate(stateMachine.idleState);
    }

    private void Update()
    {
        stateMachine.Update();
    }


    public FriendSo Getfriends()
    {
        return FriendsSo;
    }

}
