using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour {

	public UnityEngine.UI.Text StartText;
	public UnityEngine.UI.Text HitText;
	public GameObject StartGraph;
	public GameObject player;

	public float life_time;
	private float curr_t = 0f;

	// Use this for initialization
	void Start () {
		StartText.gameObject.SetActive (true);
		StartGraph.gameObject.SetActive (true);
		player.gameObject.SetActive (false);
		HitText.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		curr_t += Time.deltaTime;

		if (curr_t >= life_time) 
		{
			StartText.gameObject.SetActive (false);
			StartGraph.gameObject.SetActive (false);
			player.gameObject.SetActive (true);
			HitText.gameObject.SetActive (true);
			Destroy (gameObject);
		}

			
	}
}
