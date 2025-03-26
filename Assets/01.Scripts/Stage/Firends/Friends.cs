
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;


public class Friends : MonoBehaviour
{

    [Header("Component")]
    public  Animator animator;
    public NavMeshAgent meshAgent;
    public GameObject Target;

    [Header("Bool")]
    public bool IsInRange =false;
    public bool IsAttacking = false;
    public bool IsRange;

    [Header("Prefabs")]
    public GameObject Bullet;
    public List<Equip> equipList = new List<Equip>();


    private StateMachine stateMachine;


    [Header("Data")]
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


    public void BulletShoot()
    {
        Vector3 Dir = stateMachine.friends.Target.transform.position - stateMachine.friends.meshAgent.transform.position;
        Dir =Dir.normalized;

        
        GameObject bullet = Instantiate(Bullet, transform.position + transform.forward *3f + transform.up *0.5f, Quaternion.identity);
        bullet.transform.parent = transform;
        bullet.GetComponent<Rigidbody>().AddForce(Dir*10f, ForceMode.Impulse);
    }

}
