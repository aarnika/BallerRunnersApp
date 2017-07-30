using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour {
	//speed of the obstacle object
	public float objectSpeed = -0.6f;

	void Update () {
		if (Time.timeScale == 1) {
			//moves the transform in the distance and direction of the translation 
			transform.Translate (0, objectSpeed, 0);
		}
	}
}
