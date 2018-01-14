using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetController : MonoBehaviour {

	public bool is_correct;
	private GameController gc;
	public GameObject player;
	public GameObject[] choices;
	private Animator animator;
	private int reward;


	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gc = gameControllerObject.GetComponent<GameController> ();
		animator = player.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if( (other.gameObject.CompareTag("Tool") && animator.GetBool("AttackTool")) || other.gameObject.CompareTag("PlayerAttack"))
		{
			reward = 10;

			if (!is_correct) 
			{
				reward *= -1;
			}

			gc.SetHitPoint (reward);
			gc.UpdateHit ();
			gc.AddScore ();
			gc.UpdateScore ();

			for (int i = 0; i < choices.Length; i++) 
			{
				Destroy (choices [i]);
			}
		}
	}
}
