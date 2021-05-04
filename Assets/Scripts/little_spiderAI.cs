using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class little_spiderAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public GameObject targetOb;
    public LayerMask groundL, enemyL;
    private Animator _animator;

    public bool attacked = false;
    public float attackRange;
    public float attackGap;
    public float damage;
    public bool inRange;

    private void Awake()
    {
        target = ClosestEnemy();
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inRange = Physics.CheckSphere(transform.position, attackRange, enemyL);
        if (inRange)
        {
            attack();
        }
        else
        {
            _animator.SetBool("Attacking", false);
            target = ClosestEnemy();
            agent.SetDestination(target.position);
        }
        if (gameObject.GetComponent<EnemyHealth>().health <= 0)
        {
            _animator.SetBool("Died", true);
        }
    }

    private Transform ClosestEnemy()
    {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Good");
        float dis = 10000f;
        Transform enemyC = null;
        if (enemyList == null)
        {
            return null;
        }
        else
        {
            for (int i = 0; i < enemyList.Length; i++)
            {
                GameObject e = enemyList[i];
                float d = Vector3.Distance(transform.position, e.transform.position);
                if (d < dis)
                {
                    dis = d;
                    enemyC = e.transform;
                    targetOb = e;
                }
            }
            return enemyC;
        }
    }

    private void attack()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(target);

        if (!attacked)
        {
            _animator.SetBool("Attacking", true);
            if (targetOb.name == "Player")
            {
                targetOb.GetComponent<status>().Hurt(damage);
            }
            attacked = true;
            _animator.SetBool("Attacking", false);
            Invoke(nameof(ResetAttack), attackGap);
        }
    }

    private void ResetAttack()
    {
        attacked = false;
    }
}
