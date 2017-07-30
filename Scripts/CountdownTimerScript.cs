using UnityEngine;
using System.Collections;

public class CountdownTimerScript : MonoBehaviour {

	public GameObject character;
	public GameObject wall1;
	public GameObject wall2;
	public GameObject ground;

	public int countMax;  //max countdown number
	private int countDown;  //current countdown number
	public GUIText guiTextCountdown;//GUIText reference
	//Used for initialization
	void Start () {
		MonoBehaviour[] scriptComponentsControlGame = gameObject.GetComponents<MonoBehaviour>();   //get all the script components attached
		//loop through all the scripts and disable them
		foreach(MonoBehaviour script in scriptComponentsControlGame) {
			script.enabled = false;
		}

		//disable all the scripts attached to the walls, ground. Also disable the animation of the character.
		((ControlGround)FindObjectOfType(typeof(ControlGround))).enabled = false;
		((Animation)FindObjectOfType(typeof(Animation))).enabled = false;

		//Call the CountdownFunction
		StartCoroutine(CountdownFunction());
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator CountdownFunction() {
		//start the countdown after clicking play in the application 
		for(countDown = countMax; countDown>-1;countDown--){
			if(countDown!=0){
				//display the number to the screen via the GUIText
				guiTextCountdown.text = countDown.ToString();
				//add a one second delay
				yield return new WaitForSeconds(1);    
			}
			else{
				guiTextCountdown.text = "GO HOME!";
				yield return new WaitForSeconds(1);
			}
		}
		//enable all the scripts and animation once the count is down
		MonoBehaviour[] scriptComponentsGameControl = gameObject.GetComponents<MonoBehaviour>();   
		foreach(MonoBehaviour script in scriptComponentsGameControl) {
			script.enabled = true;
		}
		((ControlGround)FindObjectOfType(typeof(ControlGround))).enabled = true;
		((Animation)FindObjectOfType(typeof(Animation))).enabled = true;
	
		//disable the GUIText once the countdown is done with
		guiTextCountdown.enabled = false;
	}
}
