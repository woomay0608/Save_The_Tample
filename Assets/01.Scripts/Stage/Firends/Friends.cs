
using System.Collections.Generic;
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
   
    public List<Equip> equipList=  new List<Equip>();

    [SerializeField] FriendSo FriendsSo;
    [SerializeField] FriendsStat FriendsStat;
    
    private void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
        animator = GetComponentInChildren<Animator>();
        meshAgent = GetComponent<NavMeshAgent>();
        FriendsStat = GetComponent<FriendsStat>();
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
    public FriendsStat GetfriendsStat() {  return FriendsStat; }

    private void OnMouseDown()
    {
        StageInfoManager.Instance.SetFriend(this);
    }

}
