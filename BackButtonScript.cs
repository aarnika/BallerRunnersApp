using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScript : MonoBehaviour {
	//Button to go back to main menu
	public void BackButton(string back){
		Application.LoadLevel (back);
	}
}
