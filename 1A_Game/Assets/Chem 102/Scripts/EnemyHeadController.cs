using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeadController : MonoBehaviour {

	public GameObject enemy;
	private int reward = 5;
	private GameController gc;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gc = gameControllerObject.GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Feet")) {
			
			gc.SetHitPoint (reward);
			gc.UpdateHit ();
			gc.AddScore ();
			gc.UpdateScore ();
			Destroy (enemy);
		}
	}

	void OnDestroy()
	{
		Destroy (enemy);
	}
}
