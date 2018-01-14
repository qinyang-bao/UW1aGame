using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IclickerRequirementController : MonoBehaviour {

	public GameObject iclicker;


	void OnTriggerEnter2D(Collider2D other)
	{
		if (iclicker.activeSelf) 
		{
			Destroy (gameObject);
		}
	}
}
