using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax;
}

public class EnemyController : MonoBehaviour {

	public GameObject attack_one;
	public GameObject attack_two;
	public Transform spawnPos;

	public GameObject player;
	private Rigidbody2D rb;
	public Boundary boundary;
	private SpriteRenderer spriteRenderer;

	public float move_speed;

	public float attack_rate;
	private float next_attack;

	public float distance_lim_square;
	protected Vector2 direction;


	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		boundary.xMax = transform.position.x + boundary.xMax;
		boundary.xMin = transform.position.x - boundary.xMin;
		next_attack = 0f;

	}

	void Update () {
		Vector2 distance = player.transform.position - transform.position;
		direction = distance;

		if (distance.sqrMagnitude < distance_lim_square && Time.time > next_attack) 
		{
			next_attack += attack_rate;

			float rand_num = Random.value;
			GameObject to_instantiate = attack_one;

			if (rand_num > 0.5) {
				to_instantiate = attack_two;
			}

			//flip sprite to the side facing the player
			float dot = -player.transform.position.x * transform.position.y + player.transform.position.y * transform.position.x;
			if (dot < 0 && !spriteRenderer.flipX) {
				spriteRenderer.flipX = true;
				//spawnPos.transform.position = initialSpawnPos;
			} else if (dot > 0 && spriteRenderer.flipX) {
				spriteRenderer.flipX = false;
				//spawnPos.transform.position = -10*initialSpawnPos;
			}

			GameObject instance = Instantiate (to_instantiate, spawnPos.position, Quaternion.identity) as GameObject;
			AttackMover script = instance.GetComponent<AttackMover> ();
			script.direction = distance / distance.magnitude;

			//flips back after attack
			if (dot > 0 && spriteRenderer.flipX) {
				spriteRenderer.flipX = false;
				//spawnPos.transform.position = -10*initialSpawnPos;
			} else if (dot < 0 && !spriteRenderer.flipX) {
				spriteRenderer.flipX = true;
				//spawnPos.transform.position = initialSpawnPos;
			}
		}


		if (!spriteRenderer.flipX && transform.position.x < boundary.xMax) {
			rb.velocity = Vector2.right * move_speed;
		} 
		if (!spriteRenderer.flipX && transform.position.x >= boundary.xMax) {
			rb.velocity = Vector2.zero;
			spriteRenderer.flipX = true;
			//spawnPos.transform.position = initialSpawnPos;
		} 
		if (spriteRenderer.flipX && transform.position.x > boundary.xMin) {
			rb.velocity = Vector2.left * move_speed;
		}
		if (spriteRenderer.flipX && transform.position.x <= boundary.xMin) {
			rb.velocity = Vector2.zero;
			spriteRenderer.flipX = false;
			//spawnPos.transform.position = -10*initialSpawnPos;
		}
	}
		

}