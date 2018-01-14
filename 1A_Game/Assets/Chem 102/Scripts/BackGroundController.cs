using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour {


	//public GameObject player;
	//public float offset;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		audioSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = new Vector2 (player.transform.position.x + offset, 0.0f);
		//audioSource.Play ();
	}
}
