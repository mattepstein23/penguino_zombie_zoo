using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class vacAI : MonoBehaviour
{
    private SpawnController spawnController;
    private ScoreTracker scoreTracker;
    public NavMeshAgent agent;
    public Transform target;
    public LayerMask groundL, enemyL;

    public bool attacked = false;
    public float attackRange;
    public float range;
    public bool inRange;

    private MeshRenderer[] mat;
    private Animator anim;
    private ParticleSystem ps;

    [SerializeField] GameObject explosion;

    private void Awake()
    {
        target = ClosestEnemy();
        anim = GetComponent<Animator>();
        ps = GetComponent<ParticleSystem>();
        agent = GetComponent<NavMeshAgent>();
        spawnController = GameObject.Find("SpawnController").GetComponent<SpawnController>();
        scoreTracker = GameObject.Find("ScoreValue").GetComponent<ScoreTracker>();
    }

    // Start is called before the first frame update
    void Start()
    {
        changeVaxxedMaterial();
        ps.Play();
    }

    private void changeVaxxedMaterial()
    {
        mat = this.gameObject.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < mat.Length; i++)
        {
            mat[i].material.mainTextureScale = new Vector2(1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        inRange = Physics.CheckSphere(transform.position, attackRange, enemyL);
        if (inRange)
        {
            Boom();
            GameObject.Instantiate(this.explosion, this.transform.position, new Quaternion());
        }
        else
        {
            target = ClosestEnemy();
            anim.SetInteger("Walk", 1);
            agent.SetDestination(target.position);
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
                Transform e = enemyList[i].transform;
                float d = Vector3.Distance(transform.position, e.position);
                if (d < dis)
                {
                    dis = d;
                    enemyC = e;
                }
            }
            return enemyC;
        }
    }

    private void Boom()
    {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemyList.Length; i++)
        {
            Transform e = enemyList[i].transform;
            float d = Vector3.Distance(transform.position, e.position);
            if (d < range)
            {
                scoreTracker.addScore(100);
                Destroy(enemyList[i]);
                spawnController.AddKill();
                attacked = true;
            }
        }
        if (attacked)
        {
            Destroy(gameObject);
        }
    }
}
