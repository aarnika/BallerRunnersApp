using System.Collections;

public class PauseScript : MonoBehaviour 
{
	public GUISkin skin;  //custom GUIskin reference
	public string levelToLoad;
	public bool paused = false;

	 void Start()
	{
  //Makes restart option work
		Time.timeScale=1;  
	}

	 void Update()
	{
		if(paused)
			Time.timeScale = 0;  //procedings are halted
		else
			Time.timeScale = 1;  //unpauses the game

	}

	 void OnGUI()
	{
		GUI.skin=skin;   //use the custom GUISkin

		if (paused){    

			GUI.Box(new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), "PAUSED");
			//GUI.Label(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "YOUR SCORE: "+ ((int)score));

			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+Screen.height/10+10, Screen.width/2-20, Screen.height/10), "RESUME")){
				paused = false;
			}

			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+2*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "RESTART")){
				Application.LoadLevel(Application.loadedLevel);
			}

			if (GUI.Button(new Rect(Screen.width/4+10, Screen.height/4+3*Screen.height/10+10, Screen.width/2-20, Screen.height/10), "MAIN MENU")){
				Application.LoadLevel(levelToLoad);
			} 
		}
	}
}
