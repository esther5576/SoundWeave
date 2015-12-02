using UnityEngine;
using System.Collections;


public class UserInput : MonoBehaviour
{

	public bool walkByDefault = false;

	private CharMove character;
	private Transform cam;
	private Vector3 camForward;
	private Vector3 move;

	//Camera
	public bool aim = false;
	public float aimingWeight;

	//Aiming Assist
	private RaycastHit lastRaycastHit;
	
	[Tooltip("Range of the Raycast = how far you can choose to teleport")]
	public float
		range = 10.0f;

	public GameObject cameraContainer;

	public bool jump;

	void Start ()
	{

		/*cameraContainer = GameObject.Find ("Camera");
		
		if (Camera.main != null) {
			cam = Camera.main.transform;
		}*/

		character = GetComponent<CharMove> ();
	}

	void LateUpdate ()
	{
		//Aiming systhem
		//if (Input.GetAxis ("360_Triggers") < 0) 
		/*if (Input.GetKey (KeyCode.Joystick1Button8)) {
			aim = true;
		} else {
			aim = false;
		}

		aimingWeight = Mathf.MoveTowards (aimingWeight, (aim) ? 1.0f : 0.0f, Time.deltaTime * 5);
		
		Vector3 normalState = new Vector3 (0, 0, -2f);
		Vector3 aimingState = new Vector3 (0.25f, 0, -0.5f);
		
		Vector3 pos = Vector3.Lerp (normalState, aimingState, aimingWeight);
	
		cam.transform.localPosition = pos;*/
	}

	void FixedUpdate ()
	{

		/*float horizontal = Input.GetAxis ("LeftStickX");
		float vertical = Input.GetAxis ("LeftStickY");


		if (cam != null) {
			camForward = Vector3.Scale (cam.forward, new Vector3 (1, 0, 1)).normalized;
			move = -vertical * camForward + horizontal * cam.right;
		} else {
			move = -vertical * Vector3.forward + horizontal * Vector3.right;
		}

		if (move.magnitude > 1)
			move.Normalize ();

		//running shift disabled when aimming
		bool walkToggle = Input.GetKey (KeyCode.LeftShift);

		float walkMultiplier = 1;

		if (walkByDefault) {
			if (walkToggle) {
				walkMultiplier = 1;
			} else {
				walkMultiplier = 0.5f;
			}
		} else {
			if (walkToggle) {
				walkMultiplier = 0.5f;
			} else {
				walkMultiplier = 1;
			}
		}

		move *= walkMultiplier;*/
		character.Move (move);
	}
}