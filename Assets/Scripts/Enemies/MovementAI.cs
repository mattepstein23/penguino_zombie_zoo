using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAI : MonoBehaviour
{
	public float speed = 3.0f;
	public float obstacleRange = 5.0f;

	[SerializeField] private int jumpRange = 10;
	private GameObject _fireball;
	Rigidbody rb;
	public float jumpForce = 50;
	public float timeBeforeNextJump = 1.2f;
	private float canJump = 0f;

	private GameObject player;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		player = GameObject.Find("Player");
		rb.freezeRotation = true;
	}

	void Update()
	{
		Vector3 playerPosition = player.transform.position;
			
		Vector3 newPos = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
		transform.position = newPos;

		int randomChoice = Random.Range(0, jumpRange);
		if (randomChoice == 0 && Time.time > canJump)
		{
			rb.constraints = RigidbodyConstraints.FreezeRotation;
			rb.AddForce(0, jumpForce, 0);
			canJump = Time.time + timeBeforeNextJump;
		}
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
			StartCoroutine(DamagePlayer(collision.gameObject.GetComponent<status>()));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
		if (collision.gameObject.name == "Player")
		{
			StopAllCoroutines();
		}
	}

    private IEnumerator DamagePlayer(status health)
    {
		while (true)
        {
			health.Hurt(0.5f);
			yield return new WaitForSeconds(0.5f);
		}
    }

}
