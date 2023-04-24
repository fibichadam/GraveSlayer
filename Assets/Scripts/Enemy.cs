using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private float timeOfLastAttack = 0;
    private bool hasStopped = false;

    private NavMeshAgent agent = null;
    private Animator anim = null;
    private EnemyStats stats = null;
    [SerializeField] private Transform target;

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        GetReferences();        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }


    private void MoveToTarget()
    {
        agent.SetDestination(target.position);

        RotateToTarget();

        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            anim.SetFloat("Speed", 0f, 0.3f, Time.deltaTime);

            //Attack
            if (!hasStopped) 
            {
                hasStopped = true;
                timeOfLastAttack = Time.time;
            }

            if (Time.time >= timeOfLastAttack + stats.attackSpeed)
            {
                
                timeOfLastAttack = Time.time;
                CharacterStats targetStats = target.GetComponentInParent<CharacterStats>();
                AttackTarget(targetStats);
            }
        }
        else
        {
            anim.SetFloat("Speed", speed/4.5f, 0.3f, Time.deltaTime);
            hasStopped = false;
        }
    }

    private void RotateToTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction+new Vector3(0f,-1f,0f), Vector3.up);
        transform.rotation = rotation;
    }

    private void AttackTarget(CharacterStats statsToDamage)
    {
        anim.SetTrigger("Attack");
        stats.DealDamage(statsToDamage);
    }


    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        stats = GetComponent<EnemyStats>();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();

        speed = Random.Range(2f, 4.5f);
        agent.speed = speed;
    }

}
