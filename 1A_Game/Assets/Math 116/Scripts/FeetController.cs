using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetController : MonoBehaviour {
	//private Animator animator;
	public GameObject player;
	private gameControl gc;

	private PhysicalObject player_object;
	private bool is_falling = false, on_boundary = false, start_counting = false;
	private Vector2 fall_position = new Vector2 (0f, 0f);
	public int pulishment = 10;
	public float curr_t = 0f;
	public float delay_time = 1f;

	// Use this for initialization
	void Start () {
		//animator = player.GetComponent<Animator> ();
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gc = gameControllerObject.GetComponent<gameControl> ();

		player_object = player.GetComponent<PhysicalObject> ();
	}

	void Update()
	{
		if (player_object.get_velocity ().y < 0 && !is_falling && !on_boundary) {
			is_falling = true;
			fall_position = player.transform.position;
		}

		if (on_boundary && !is_falling) 
		{
			/*
			Debug.Log ("Yes");
			if (!start_counting) {
				start_counting = true;
			}

			if (start_counting) {
				curr_t += Time.deltaTime;
				if (curr_t >= delay_time) {
					Debug.Log (curr_t.ToString ());
					player.transform.position = fall_position;
					on_boundary = false;
					is_falling = false;

					curr_t = 0;
					start_counting = false;
				}
			}
			*/

			player.transform.position = fall_position;
			on_boundary = false;
			is_falling = false;
		}
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (player_object.is_grounded() && !other.gameObject.CompareTag ("Boundaries")){
			on_boundary = false;
			is_falling = false;
		}

		if (other.gameObject.CompareTag ("Boundaries")) {
			//animator.SetBool ("Die", true);
			on_boundary = true;
			is_falling = false;

			gc.SetHitPoint (-pulishment);
			gc.UpdateHit ();
			gc.AddScore ();
			gc.UpdateScore ();
		}
	}
}
