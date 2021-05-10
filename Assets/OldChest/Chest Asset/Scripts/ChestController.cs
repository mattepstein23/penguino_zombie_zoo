using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{

    [SerializeField] public GameObject enemyToSpawn;
    [SerializeField] public GameObject dirtParticles;

    [SerializeField] public AudioClip goodOpen;
    [SerializeField] public AudioClip badOpen;

    private AudioSource source;

    [SerializeField] public bool spawnFront = false;

    private bool alreadyOpened = false; 
    int random;

    private bool activateSpawn = false;
    private GameObject enemySpawn;
    private Rigidbody enemyRb;
    private BoxCollider enemyCollider;
    private MovementAI enemyAI;

    private SpawnController spawnController;

    private AutomaticGunScriptLPFP playerController;

    [SerializeField]
    public GameObject vaxAdd;
    [SerializeField]
    public GameObject enemyAdd;
    

    // Start is called before the first frame update
    void Start()
    {
        spawnController = GameObject.Find("SpawnController").GetComponent<SpawnController>();
        playerController = GameObject.Find("arms_assault_rifle_01").GetComponent<AutomaticGunScriptLPFP>();
        source = this.gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (activateSpawn)
        {
            enemySpawn.transform.Translate(new Vector3(0, 0.5f, 0) * Time.deltaTime);
            if (enemySpawn.transform.position.y >= 0.2)
            {
                activateSpawn = false;
                enemyRb.useGravity = true;
                enemyCollider.enabled = true;
                enemyAI.jumpEnabled = true;
                enemyAI.trackingEnabled = true;
            }
        }
    }

    // Update is called once per frame
    public void Open() {
        if (!alreadyOpened)
        {
            this.gameObject.GetComponentInChildren<Exclamation>().Disable();
            alreadyOpened = true;
            random = Random.Range(0, 2);
            this.GetComponent<Animator>().SetTrigger("OpenChest");
            Debug.Log("I'm Opening");

            if (random == 0)
            {
                source.clip = goodOpen;
                source.Play();
                StartCoroutine(AddLabel(vaxAdd));
                this.playerController.addVac();
            }

            if (random == 1)
            {
                source.clip = badOpen;
                source.Play();
                StartCoroutine(AddLabel(enemyAdd));
                StartCoroutine(EnemySpawn());
            }
            //if(random == 2){
            //    Debug.Log("Ability Two activated"); 
            //}
        }
    }

    private IEnumerator AddLabel(GameObject obj)
    {
        yield return new WaitForSeconds(1);
        obj.SetActive(true);
        yield return new WaitForSeconds(3);
        obj.SetActive(false);
    }

    private IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(2);
        enemySpawn = GameObject.Instantiate(enemyToSpawn);
        Vector3 enemyPos = this.gameObject.transform.position;
        enemyPos.y -= 2;
        if (spawnFront)
        {
            enemyPos.z -= 4.5f;
        }
        else
        {
            enemyPos.z += 4.5f;
        }
        StartCoroutine(SpawnDirt(enemyPos));
        yield return new WaitForSeconds(1);
        enemySpawn.transform.position = enemyPos;
        enemyRb = enemySpawn.GetComponent<Rigidbody>();
        enemyCollider = enemySpawn.GetComponent<BoxCollider>();
        enemyAI = enemySpawn.GetComponent<MovementAI>();
        enemyAI.jumpEnabled = false;
        enemyCollider.enabled = false;
        enemyRb.useGravity = false;
        enemyAI.trackingEnabled = false;
        spawnController.AddEnemy();
        this.activateSpawn = true;
    }

    private IEnumerator SpawnDirt(Vector3 pos)
    {
        GameObject dirt = GameObject.Instantiate(dirtParticles);
        pos.y = 0;
        dirt.transform.position = pos;
        yield return new WaitForSeconds(4);
        Destroy(dirt);
    }

}
