using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IclickerController : MonoBehaviour {

	public GameObject iclicker;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player") || other.gameObject.CompareTag ("Feet"))
		{
			iclicker.SetActive (true);
			Destroy (gameObject);
		}

	}
}
