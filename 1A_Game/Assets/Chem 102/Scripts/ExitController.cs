using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour {

	public UnityEngine.UI.Text ExitText;
	public GameObject ExitGraph;
	//public string next_level_name;
	public int next_level_index;

	private GameController gc;
	public GameObject player_body;
	public GameObject player;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gc = gameControllerObject.GetComponent<GameController> ();
		ExitText.text = "";
		ExitText.gameObject.SetActive (false);
		ExitGraph.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (gc.score == 0) 
		{
			ExitText.gameObject.SetActive (true);
			ExitGraph.gameObject.SetActive (true);
			ExitText.text = "You have failed Chem102! Press 'R' to repeat!";
			if (Input.GetKeyDown (KeyCode.R)) 
			{
				SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().name);
			}
		}

		if (player.transform.position.y <= -35f) 
		{
			
			ExitText.gameObject.SetActive (true);
			ExitGraph.gameObject.SetActive (true);
			ExitText.text = "You have suicided under tremendous pressure of Chem102! Press 'R' to repeat!";
			if (Input.GetKeyDown (KeyCode.R)) 
			{
				SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().name);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if( other.gameObject.CompareTag("Player") )
		{
			ExitText.gameObject.SetActive (true);
			ExitGraph.gameObject.SetActive (true);
			if (gc.score >= 60) {
				ExitText.text = "Congurations! You have passed Chem102 with a grade of: " + gc.score.ToString () + " !"+ "Press 'N' to advance!";
				if (Input.GetKeyDown (KeyCode.N)) 
				{
					SceneManager.LoadSceneAsync (next_level_index);
				}
				//Destroy (gameObject);
			} else {
				ExitText.text = "Sorry, you have failed Chem102 with a grade of: " + gc.score.ToString () + " !" + " Press 'R' to repeat!";
				if (Input.GetKeyDown (KeyCode.R)) 
				{
					SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().name);
				}
				//Destroy (gameObject);
			}


		}
	}

}
