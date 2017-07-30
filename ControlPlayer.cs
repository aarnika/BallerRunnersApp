using UnityEngine;
using System.Collections;

public class ControlPlayer : MonoBehaviour {
	public ControlGameScript control;
	CharacterController controller;
	bool isGrounded= false;
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	//CountdownTimerScript instance
	public CountdownTimerScript count;  

	//zero reference input.acceleration
	Vector3 zeroAcc;  
	//In-game input.acceleration
	Vector3 currentAcc; 
	//sensitivity of accelerometer
	float sensitivityH = 3; 
	//smoothness of acceleration control 
	float smooth = 0.5f; 
	float GetAxisH = 0;  

	//start 
	void Start () {
		controller = GetComponent<CharacterController>();
		zeroAcc = Input.acceleration;
		currentAcc = Vector3.zero;
	}

	// Update is called once per frame
	void Update (){
		currentAcc = Vector3.Lerp(currentAcc, Input.acceleration-zeroAcc, Time.deltaTime/smooth);
		GetAxisH = Mathf.Clamp(currentAcc.x * sensitivityH, -1, 1);
		int fingerCount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				fingerCount++; 
		}
		if (controller.isGrounded) {
			Animation animation = GetComponent<Animation> ();
			animation.Play("HumanoidRun");            //play "run" animation if spacebar is not pressed	
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
			moveDirection = new Vector3(GetAxisH, 0, 0);
			moveDirection = transform.TransformDirection(moveDirection);  //apply this direction to the character
			moveDirection *= speed;            //increase the speed of the movement by the factor "speed" 

			if (fingerCount >= 1) {
				animation = GetComponent<Animation> ();
				animation.Stop ("HumanoidRun");
				animation.Play ("HumanoidJumpUp");

				moveDirection.y = jumpSpeed;
			}
			if (Input.GetButton ("Jump")) {          //play "Jump" animation if character is grounded and spacebar is pressed
				animation = GetComponent<Animation>();
				animation.Stop("HumanoidRun");
				animation.Play("HumanoidJumpUp");

				moveDirection.y = jumpSpeed;//add jump height to the character
			}

		}
		// Apply gravity
		moveDirection.y -= gravity * Time.deltaTime;

		// Move the controller
		controller.Move(moveDirection * Time.deltaTime);
	}

	//check if the character collects the powerups or the snags
	void OnTriggerEnter(Collider other)
	{               
		if(other.gameObject.name == "Powerup(Clone)")
		{
			control = (ControlGameScript)FindObjectOfType (typeof(ControlGameScript));
			control.PowerupCollected();
		}
		else if(other.gameObject.name == "Obstacle(Clone)" && isGrounded == true)
		{
			control = (ControlGameScript)FindObjectOfType (typeof(ControlGameScript));
			control.AlcoholCollected();
		}

		Destroy(other.gameObject);

	}
}
