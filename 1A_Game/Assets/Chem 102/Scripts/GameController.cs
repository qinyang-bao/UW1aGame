using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


	public UnityEngine.UI.Text scoreText;
	public int score;
	public UnityEngine.UI.Text hitText;
	private int hit_value;
	public int attack_count = 0;
	private DestroyByTime dtime;


	// Use this for initialization
	void Start () {
		score = 100;
		UpdateScore ();
		hit_value = 0;
		//UpdateHit ();

		dtime = GetComponent<DestroyByTime> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetHitPoint (int value)
	{
		hit_value = value;
	}

	public void AddScore ()
	{
		score = score + hit_value;
		if (score > 100)
			score = 100;
		if (score < 0) {
			score = 0;
			hit_value = 0;
		}
	}

	public void UpdateHit ()
	{
		hitText.text = hit_value.ToString();

		if (hit_value > 0) 
		{
			hitText.text = "+" + hit_value.ToString ();
		}

		hitText.gameObject.SetActive (true);
		if(dtime!= null)
			dtime.curr_t = 0;
	}

	public void UpdateScore()
	{
		//scoreText.text = "Grade: " + score.ToString() + "Hit: " + hit_value.ToString ();
		scoreText.text = "Grade: " + score.ToString();
	}
}
