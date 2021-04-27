using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{

    [SerializeField] public GameObject enemyToSpawn;

    private bool alreadyOpened = false; 
    int random;

    private bool activateSpawn = false;
    private GameObject enemySpawn;
    private Rigidbody enemyRb;
    private BoxCollider enemyCollider;
    private MovementAI enemyAI;

    private SpawnController spawnController;

    private AutomaticGunScriptLPFP playerController;
    

    // Start is called before the first frame update
    void Start()
    {
        spawnController = GameObject.Find("SpawnController").GetComponent<SpawnController>();
        playerController = GameObject.Find("arms_assault_rifle_01").GetComponent<AutomaticGunScriptLPFP>();
    }

    private void Update()
    {
        if (activateSpawn)
        {
            enemySpawn.transform.Translate(new Vector3(0, 0.5f, 0) * Time.deltaTime);
            if (enemySpawn.transform.position.y >= 0)
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
        alreadyOpened = true;
        random = Random.Range(0,2); 
        this.GetComponent<Animation>().Play("ChestAnim");
        Debug.Log("I'm Opening"); 

        if(random == 0){
            this.playerController.addVac();
            StartCoroutine(AddVacLabel());
        }

        if(random == 1){
            enemySpawn = GameObject.Instantiate(enemyToSpawn);
            Vector3 enemyPos = this.gameObject.transform.position;
            enemyPos.y -= 2;
            enemyPos.z -= 4.5f;
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
        //if(random == 2){
        //    Debug.Log("Ability Two activated"); 
        //}
    }

    private IEnumerator AddVacLabel()
    {
        UnityEngine.UI.Text vaxLabel = GameObject.Find("VaxAdd").GetComponent<UnityEngine.UI.Text>();
        vaxLabel.text = "Vaccination Added";
        yield return new WaitForSeconds(3);
        vaxLabel.text = "";
    }
}
