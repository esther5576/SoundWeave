using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(CapsuleCollider))]
public class PlayerInput : MonoBehaviour
{

	#region Camera system
	[Tooltip("Aiming system activated")]
	public bool
		aim = false;
	private float aimingWeight;
	private GameObject cameraContainer;
	private Transform cam;
	[Tooltip("Normal position of the camera")]
	public Vector3
		_normalState = new Vector3 ();
	[Tooltip("Aiming position of the camera")]
	public Vector3
		_aimingState = new Vector3 ();
	#endregion

	#region Player movement
	[Tooltip("Speed multiplier of the player")]
	public float
		speed = 0.25f;
	private Vector3 movement = new Vector3 ();
	private Vector3 forward = new Vector3 ();
	private Vector3 right = new Vector3 ();
	#endregion

	#region Player jump & ground checking
	public bool grounded;
	public float jumpForce = 10;
	public bool candoubleJump;
	IComparer rayHitComparer;
	public int count;
	#endregion

	//GameObject UI_pointer;

	void Awake ()
	{
		//UI_pointer = GameObject.Find ("Pointer");
	}

	// Use this for initialization
	void Start ()
	{
		#region Camera system
		cameraContainer = GameObject.Find ("Camera");
		
		if (Camera.main != null) {
			cam = Camera.main.transform;
		}
		#endregion
	}

	void LateUpdate ()
	{
		#region Aiming system
		//Aiming system
		if (Input.GetKey (KeyCode.Joystick1Button8)) {
			aim = true;
		} else {
			aim = false;
		}
		
		aimingWeight = Mathf.MoveTowards (aimingWeight, (aim) ? 1.0f : 0.0f, Time.deltaTime * 5);
		
		Vector3 normalState = _normalState;
		Vector3 aimingState = _aimingState;
		
		Vector3 pos = Vector3.Lerp (normalState, aimingState, aimingWeight);
		
		cam.transform.localPosition = pos;

		if (aim == false) {
			//UI_pointer.GetComponent<CanvasGroup> ().alpha = 0;
		} else {
			//UI_pointer.GetComponent<CanvasGroup> ().alpha = 1;
		}
		#endregion
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		//Store input axes
		float X = Input.GetAxis ("LeftStickX");
		float Y = Input.GetAxis ("LeftStickY");

		#region stability of movement 
		if ((X + Y == 0) && grounded == true) {
			this.GetComponent<Rigidbody> ().MovePosition (transform.localPosition);
			this.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
		}
		if (/*(X + Y == 0) &&*/ grounded == false) {
			this.GetComponent<Rigidbody> ().velocity += new Vector3 (0, -1.5f, 0);
		}

		Physics.gravity = new Vector3 (0, -30.0F, 0);
		#endregion



		Move (X, Y);
		Jump ();

		GroundCheck ();
	}

	#region Move function to move the player
	/// <summary>
	/// Move the player to a specified X and Y from the input of the controller
	/// </summary>
	/// <param name="X">X.</param>
	/// <param name="Y">Y.</param>
	void Move (float X, float Y)
	{
		forward = cameraContainer.transform.TransformDirection (Vector3.forward);
		forward.y = 0;
		forward = forward.normalized;
		right = new Vector3 (forward.z, 0, -forward.x);
		
		movement = (X * right + Y * forward).normalized;
		movement *= speed;
		this.GetComponent<Rigidbody> ().MovePosition (transform.localPosition + movement);
	}
	#endregion

	#region Function to make the player jump
	/// <summary>
	/// Make the player jump with this function
	/// </summary>
	void Jump ()
	{
		if (Input.GetKeyDown (KeyCode.JoystickButton0)) {
			if (grounded) {
				this.GetComponent<Rigidbody> ().velocity += jumpForce * Vector3.up;
				candoubleJump = true;
				//FMODUnity.RuntimeManager.PlayOneShot ("event:/feedbacks/jump", transform.localPosition);
			} else if (candoubleJump) {
				candoubleJump = false;
				this.GetComponent<Rigidbody> ().velocity += jumpForce * Vector3.up;

			}
		}

		if (Input.GetKey (KeyCode.JoystickButton1)) {
			Debug.Log ("caca");
			//this.GetComponent<Rigidbody> ().velocity += jumpForce * Vector3.up;
			this.GetComponent<Rigidbody> ().AddForce (Vector3.up * 10, ForceMode.Acceleration);
		}
	}
	#endregion

	#region Function that checks if the player is grounded
	/// <summary>
	/// Check if the player is in collision with the ground
	/// </summary>
	void GroundCheck ()
	{
		Ray ray = new Ray (transform.position + Vector3.up * .1f, -Vector3.up);
		
		RaycastHit[] hits = Physics.RaycastAll (ray, .1f);
		rayHitComparer = new RayHitComparer ();
		System.Array.Sort (hits, rayHitComparer);
		
		if (this.GetComponent<Rigidbody> ().velocity.y < jumpForce * .5f) { 	
			grounded = false;
			this.GetComponent<Rigidbody> ().useGravity = true;
			
			foreach (var hit in hits) { 
				if (!hit.collider.isTrigger) {
					if (this.GetComponent<Rigidbody> ().velocity.y <= 0) {
						//this.GetComponent<Rigidbody> ().position = Vector3.MoveTowards (this.GetComponent<Rigidbody> ().position, hit.point, Time.deltaTime * 100);
					}
					candoubleJump = true;
					grounded = true;

					count ++;

					if (count <= 1) {
						//FMODUnity.RuntimeManager.PlayOneShot ("event:/feedbacks/land", transform.localPosition);
					}

					this.GetComponent<Rigidbody> ().useGravity = false; 
				}
			}
		} else {
			grounded = false;
			count = 0;
			this.GetComponent<Rigidbody> ().useGravity = true;
		}
	}
	#endregion

	#region Class IComparer
	class RayHitComparer : IComparer
	{
		public int Compare (object x, object y)
		{
			return ((RaycastHit)x).distance.CompareTo (((RaycastHit)y).distance);
		}
	}
	#endregion
}
