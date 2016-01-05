using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
	private Transform _ParentTransform;
	private Rigidbody _Rigidbody;


	public float _FallSpeed = 1;
	public bool _Grounded = false;


	private bool _IsJumping = false;
	private float _CurrentJumpPower;
	public float _JumpPower = 5;
	public float _JumpDegradation = 0.1f;

	// Use this for initialization
	void Awake ()
	{

		_ParentTransform = transform.parent;
		_Rigidbody = transform.parent.GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!_Grounded) {
			Fall ();
		} else if (Input.GetKeyDown (KeyCode.JoystickButton0) || Input.GetKeyDown (KeyCode.JoystickButton4)) {
			Debug.Log ("jump");
			_IsJumping = true;
			_CurrentJumpPower = _JumpPower;
		}

		if (Input.GetKey (KeyCode.JoystickButton0) || Input.GetKey (KeyCode.JoystickButton4)) {
			if (_CurrentJumpPower > 0) {
				_CurrentJumpPower -= _JumpDegradation;
			}
		}

		if (Input.GetKeyUp (KeyCode.JoystickButton0) || Input.GetKeyUp (KeyCode.JoystickButton4)) {
			_IsJumping = false;
		}
	}

	void FixedUpdate ()
	{
		if (_IsJumping) {
			_Rigidbody.velocity = new Vector3 (_Rigidbody.velocity.x, _Rigidbody.velocity.y + _CurrentJumpPower, _Rigidbody.velocity.z);
		}
	}

	void Fall ()
	{
		_Rigidbody.velocity = new Vector3 (_Rigidbody.velocity.x, _Rigidbody.velocity.y - _FallSpeed, _Rigidbody.velocity.z);
	}
}
