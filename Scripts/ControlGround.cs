using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGround : MonoBehaviour {

	//Material texture offset rate
	float speed = .6f;

	//Offset the material texture at a constant rate
	void Update () {
		float offset = Time.time * speed;                             
		GetComponent <Renderer> ().material.mainTextureOffset = new Vector2(0, -offset); 
	}
}
