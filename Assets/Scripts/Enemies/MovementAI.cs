using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAI : MonoBehaviour
{
	public float speed = 3.0f;
	public float obstacleRange = 5.0f;

	[SerializeField] private int jumpRange = 10;
	private GameObject _fireball;
	private bool _alive;
	Rigidbody rb;
	public float jumpForce = 50;
	public float timeBeforeNextJump = 1.2f;
	private float canJump = 0f;

	private GameObject player;

	void Start()
	{
		_alive = true;
		rb = GetComponent<Rigidbody>();
		player = GameObject.Find("Player");
		rb.freezeRotation = true;
	}

	void Update()
	{
		if (_alive)
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

			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.SphereCast(ray, 0.75f, out hit))
			{
				GameObject hitObject = hit.transform.gameObject;
				if (hit.distance < obstacleRange)
				{
					float angle = Random.Range(-110, 110);
					//transform.Rotate(0, angle, 0);
				}
			}
		}
	}

	public void SetAlive(bool alive)
	{
		_alive = alive;
	}
}
