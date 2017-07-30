using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZoneScript : MonoBehaviour {

	//Destorys objects that the character collides with 
	void OnTriggerEnter(Collider other){
		Destroy (other.gameObject);
}
}
