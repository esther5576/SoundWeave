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
		if (!jumpScript._Grounded) {
			if (Input.GetKey (KeyCode.JoystickButton0)) {
				jumpScript._FallSpeed = GlideForce;
				characterMoveScript._Speed = GlideSpeed;
			}
			if (Input.GetKeyUp (KeyCode.JoystickButton0)) {
				jumpScript._FallSpeed = jumpFallSpeed;
				characterMoveScript._Speed = characterMoveSpeed;
			}
		} else {
			jumpScript._FallSpeed = jumpFallSpeed;
			characterMoveScript._Speed = characterMoveSpeed;
		}
	}
}
