using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetController : MonoBehaviour {
	private Animator animator;
	public GameObject player;

	// Use this for initialization
	void Start () {
		animator = player.GetComponent<Animator> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Boundaries")) {
			animator.SetBool ("Die", true);
		}
	}
}
