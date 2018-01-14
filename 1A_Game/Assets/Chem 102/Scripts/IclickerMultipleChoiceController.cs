using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IclickerMultipleChoiceController : MonoBehaviour {

	public bool is_correct;
	private GameController gc;
	public GameObject[] choices;
	private int reward = 10;
	private bool has_chosen = false;

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
		if( other.gameObject.CompareTag("Feet") )
		{
			if (!has_chosen) 
			{
				if (!is_correct) {
					reward = -10;
				}

				gc.SetHitPoint (reward);
				gc.UpdateHit ();
				gc.AddScore ();
				gc.UpdateScore ();

				for (int i = 0; i < choices.Length; i++) {
					if (choices [i] != this.gameObject)
						Destroy (choices [i].GetComponent<Collider2D> ());
				}
			}

			has_chosen = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Feet")) 
		{
			Destroy (gameObject.GetComponent<Collider2D> ());
		}
	}


}