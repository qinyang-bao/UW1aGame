using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MathExitController : MonoBehaviour {

	public UnityEngine.UI.Text ExitText;
	public UnityEngine.UI.Text ScoreText;
	public UnityEngine.UI.Text hitText;
	public UnityEngine.UI.Text AndrewText;
	public GameObject ExitGraph;
	//public string next_level_name;
	public int next_level_index;

	private gameControl gc;
	public GameObject player_body;
	public GameObject player;

	private bool pass = false, fail = false;
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gc = gameControllerObject.GetComponent<gameControl> ();
		ExitText.text = "";
		ExitText.gameObject.SetActive (false);
		ExitGraph.gameObject.SetActive (false);
	}
		
	void Update () {
		if (gc.score == 0) 
		{
			player.SetActive(false);
			ExitText.gameObject.SetActive (true);
			ExitGraph.gameObject.SetActive (true);
			ScoreText.gameObject.SetActive (false);
			hitText.gameObject.SetActive (false);
			AndrewText.gameObject.SetActive (false);
			ExitText.text = "You have failed Math116! Press 'R' to repeat!";
			if (Input.GetKeyDown (KeyCode.R)) 
			{
				SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().name);
				Destroy (gameObject);
			}
		}

		if (pass) {
			player.SetActive(false);
			if (Input.GetKeyDown (KeyCode.N)) 
			{
				SceneManager.LoadSceneAsync (next_level_index);
				Destroy (gameObject);
			}
		} else if (fail) {
			player.SetActive(false);
			if (Input.GetKeyDown (KeyCode.R)) 
			{
				SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().name);
				Destroy (gameObject);
			}
		}

	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if( other.gameObject.CompareTag("Player") )
		{
			ExitText.gameObject.SetActive (true);
			ExitGraph.gameObject.SetActive (true);
			ScoreText.gameObject.SetActive (false);
			hitText.gameObject.SetActive (false);
			AndrewText.gameObject.SetActive (false);
			if (gc.score >= 60) {
				pass = true;
				ExitText.text = "Congurations! You have passed Math116 with a grade of: " + gc.score.ToString () + " !"+ "Press 'N' to advance!";
			} else {
				fail = true;
				ExitText.text = "Sorry, you have failed Math116 with a grade of: " + gc.score.ToString () + " !" + " Press 'R' to repeat!";
			}


		}
	}

}
