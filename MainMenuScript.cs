using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour 
{
	public GUISkin myskin;  //custom GUIskin reference
	public string gameLevel;
	public string optionsLevel;
	public string howToPlay;

	private void OnGUI()
	{
		GUI.skin=myskin;   //use the custom GUISkin

		GUI.Box(new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), "MAIN MENU");

		if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/11+11, Screen.width/2-20, Screen.height/11), "PLAY")){
			SceneManager.LoadScene(gameLevel);
		}

		if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+2*Screen.height/11+11, Screen.width/2-20, Screen.height/11), "HOW TO PLAY")){
			SceneManager.LoadScene(howToPlay);
		}

		if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+3*Screen.height/11+11, Screen.width/2-20, Screen.height/11), "CREDITS")){
			SceneManager.LoadScene(optionsLevel);
		}

		if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+4*Screen.height/11+11, Screen.width/2-20, Screen.height/11), "EXIT")){
			Application.Quit();
		}
			

	}
}	
