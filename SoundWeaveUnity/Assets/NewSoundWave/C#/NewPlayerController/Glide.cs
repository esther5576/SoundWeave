using UnityEngine;
using System.Collections;

public class Glide : MonoBehaviour
{
	private Jump jumpScript;
	private CharacterMove characterMoveScript;
	public float GlideForce = 0.5f;
	public float GlideSpeed = 15f;
	private float characterMoveSpeed;
	private float jumpFallSpeed;
	public float gravityChanger = 1.5f;
	// Use this for initialization
	void Awake ()
	{
		jumpScript = this.GetComponent<Jump> ();
		characterMoveScript = this.GetComponent<CharacterMove> ();
		characterMoveSpeed = characterMoveScript._Speed;
		jumpFallSpeed = jumpScript._FallSpeed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!jumpScript._Grounded && this.transform.parent.GetComponent<Rigidbody> ().velocity.y <= 0) {
			if (Input.GetKey (KeyCode.JoystickButton5) || Input.GetKey (KeyCode.JoystickButton4)) {
				//Debug.Log (this.transform.parent.GetComponent<Rigidbody> ().velocity.y);
				jumpScript._FallSpeed = GlideForce;
				characterMoveScript._Speed = GlideSpeed;
				this.transform.parent.GetComponent<Rigidbody> ().AddForce (-Physics.gravity * gravityChanger);
			}
			if (Input.GetKeyUp (KeyCode.JoystickButton5) || Input.GetKeyUp (KeyCode.JoystickButton4)) {
				jumpScript._FallSpeed = jumpFallSpeed;
				characterMoveScript._Speed = characterMoveSpeed;
			}
		} else {
			jumpScript._FallSpeed = jumpFallSpeed;
			characterMoveScript._Speed = characterMoveSpeed;
		}
	}
}
