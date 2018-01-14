using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FucelCellCarController : MonoBehaviour {

	public GameObject player;
	public GameObject player_body;
	public GameObject car;

	private PlayerController playerController;
	private PhysicsObject physicsObject;

	public bool player_on = false;

	public float speed_multiplier;

	// Use this for initialization
	void Start () {
		playerController = player.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		//carBody.velocity = new Vector2 (playerBody.velocity.x, 0f);
		if(player_on)
			car.transform.position = new Vector3 (player_body.transform.position.x, car.transform.position.y, car.transform.position.z);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Feet"))
		{
			if (!player_on) 
			{
				playerController.Xmultiplier *= speed_multiplier;
				player_on = true;
			}
		}
	}


	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Feet") || other.gameObject.CompareTag ("Player")) 
		{
			playerController.Xmultiplier = 1f;
			player_on = false;
		}
	}

}
