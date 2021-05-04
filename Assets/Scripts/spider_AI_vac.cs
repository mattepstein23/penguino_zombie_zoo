using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class spider_AI_vac : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public GameObject targetOb;
    public LayerMask groundL, enemyL;
    private Animator _animator;

    public bool attacked = false;
    public float attackRange;
    public float attackGap;
    public int damage;
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
            if (target != null)
            {
                agent.SetDestination(target.position);
            }
        }
        if (gameObject.GetComponent<death_timer>().remainTime <= 0)
        {
            _animator.SetBool("Died", true);
        }
    }

    private Transform ClosestEnemy()
    {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
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
            if (targetOb.GetComponent<EnemyHealth>() != null)
            {
                targetOb.GetComponent<EnemyHealth>().Hit(damage);
                attacked = true;
                _animator.SetBool("Attacking", false);
                Debug.Log(attacked == true);
                Invoke(nameof(ResetAttack), attackGap);
            }
        }
    }

    private void ResetAttack()
    {
        attacked = false;
    }
}
