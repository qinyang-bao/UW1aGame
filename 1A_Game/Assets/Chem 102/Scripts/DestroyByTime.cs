using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {


	public float life_time;
	public float curr_t = 0f;

	void Update () {

		if (gameObject.activeSelf) {
			curr_t += Time.deltaTime;

			if (curr_t >= life_time) {
				curr_t = 0;
				gameObject.SetActive (false);
			}
		}
	}
}
