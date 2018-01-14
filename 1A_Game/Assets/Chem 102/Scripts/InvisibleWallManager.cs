using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWallManager : MonoBehaviour {

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Feet")) {
			GetComponent<Collider2D> ().isTrigger = false;
			spriteRenderer.enabled = true;
		}
	}
}
