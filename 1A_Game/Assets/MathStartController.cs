using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathStartController : MonoBehaviour {

	public UnityEngine.UI.Text StartText;
	public UnityEngine.UI.Text HitText;
	public UnityEngine.UI.Text ScoreText;
	public UnityEngine.UI.Text AndrewText;
	public GameObject StartGraph;

	public float life_time;
	private float curr_t = 0f;

	// Use this for initialization
	void Start () {
		StartText.gameObject.SetActive (true);
		StartGraph.gameObject.SetActive (true);

		HitText.gameObject.SetActive (false);
		ScoreText.gameObject.SetActive (false);
		AndrewText.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

		curr_t += Time.deltaTime;

		if (curr_t >= life_time) 
		{
			StartText.gameObject.SetActive (false);
			StartGraph.gameObject.SetActive (false);

			HitText.gameObject.SetActive (true);
			ScoreText.gameObject.SetActive (true);
			AndrewText.gameObject.SetActive (true);
			Destroy (gameObject);
		}


	}
}
