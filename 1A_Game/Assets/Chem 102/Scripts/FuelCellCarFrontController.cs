using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCellCarFrontController : MonoBehaviour {

	public GameObject car;
	public GameObject player;
	//private PlayerController playerController;
	private FucelCellCarController fucelCellCarController;

	void Start()
	{
		//playerController = player.GetComponent<PlayerController> ();
		fucelCellCarController = car.GetComponent<FucelCellCarController> ();
	}

	void Update()
	{
		if (car.transform.position.x >= 148) 
		{
			//playerController.Xmultiplier /= fucelCellCarController.speed_multiplier;
			Destroy (car.gameObject);
		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{

		if(other.gameObject.CompareTag("Wall"))
		{
			//playerController.Xmultiplier /= fucelCellCarController.speed_multiplier;
			Destroy (car.gameObject);
		}


		if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyAttack") && fucelCellCarController.player_on)
		{
			Destroy (other.gameObject);
		}
	}
}
