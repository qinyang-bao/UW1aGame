using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour {


	private int reward = 5;
	private int attack_count;

	private float next_attack = 0f;
	private float attack_rate = 1f;

	private GameController gc;
	public Animator animator;

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
		
		if (Time.time >= next_attack && animator.GetBool("AttackTool")) 
		{
			attack_count++;
			next_attack += attack_rate;
		}
			

		if(other.gameObject.CompareTag("Enemy") )
		{
			if (attack_count >= 2) {
				Destroy (other.gameObject);

				attack_count = 0;

				gc.SetHitPoint (reward);
				gc.UpdateHit ();
				gc.AddScore ();
				gc.UpdateScore ();
			}
		}

	}




}
