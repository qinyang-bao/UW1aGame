using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMover : MonoBehaviour {

	private Rigidbody2D rb;
	public float speed;
	public Vector2 direction = Vector2.zero; 

	private GameController gc;
	private int damage = 2;
	private int reward = 5;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gc = gameControllerObject.GetComponent<GameController> ();
	}

	void FixedUpdate()
	{
		//transform.position += new Vector3(direction.x, direction.y, 0f) * speed * Time.deltaTime;
		rb.velocity = direction * speed;
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if ( (gameObject.CompareTag("EnemyAttack_one") && !other.gameObject.CompareTag ("Enemy")) || (gameObject.CompareTag("EnemyAttack_two") && !other.gameObject.CompareTag ("Enemy"))
			|| (gameObject.CompareTag("PlayerAttack") && !other.gameObject.CompareTag ("Player"))
			 ) 
		{

			if (gameObject.CompareTag ("EnemyAttack_one") && (other.gameObject.CompareTag ("Player") || other.gameObject.CompareTag ("Tool")) )
			{
				gc.SetHitPoint (-damage);
				gc.UpdateHit ();
				gc.AddScore ();
				gc.UpdateScore ();
			}

			else if (gameObject.CompareTag ("EnemyAttack_two") && (other.gameObject.CompareTag ("Player") || other.gameObject.CompareTag ("Tool")) )
			{
				gc.SetHitPoint (damage);
				gc.UpdateHit ();
				gc.AddScore ();
				gc.UpdateScore ();
			}

			else if (gameObject.CompareTag ("PlayerAttack") && other.gameObject.CompareTag ("Enemy")) 
			{
				gc.attack_count++;
				if (gc.attack_count == 2) {
					Destroy (other.gameObject);
					gc.attack_count = 0;

					gc.SetHitPoint (reward);
					gc.UpdateHit ();
					gc.AddScore ();
					gc.UpdateScore ();
				}
			}

			Destroy (gameObject);
		}

	}


}
