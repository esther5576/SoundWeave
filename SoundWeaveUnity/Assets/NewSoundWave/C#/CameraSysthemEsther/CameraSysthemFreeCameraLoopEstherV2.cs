using UnityEngine;
using System.Collections;

public class CameraSysthemFreeCameraLoopEstherV2 : CameraSysthemPivotEstherV2
{


	[SerializeField]
	private float
		moveSpeed = 5f;
	//[SerializeField]
	public float
		turnSpeed = 3f;
	[SerializeField]
	private float
		turnsmoothing = 0.1f;
	//[SerializeField]
	public float
		tiltMax = 75f;
	//[SerializeField]
	public float
		tiltMin = 45f;
	//[SerializeField]
	private bool
		lockCursor = false;

	private float lookAngle;
	public float tiltAngle;

	private const float LookDistance = 100f;

	private float smoothX = 0;
	private float smoothY = 0;
	private float smoothXvelocity = 0;
	private float smoothYvelocity = 0;

	// Use this for initialization
	protected override void Awake ()
	{
		base.Awake ();

		//Screen.lockCurosr = lockCursor;

		cam = GetComponentInChildren<Camera> ().transform;

		pivot = cam.parent;
	}
	
	// Update is called once per frame
	protected override void Update ()
	{
		base.Update ();

		HandleRotationMovement ();
	}

	protected override void Follow (float deltaTime)
	{
		transform.position = Vector3.Lerp (transform.position, target.position, deltaTime * moveSpeed);
	}

	void HandleRotationMovement ()
	{
		float x = Input.GetAxis ("RightStickY");
		float y = Input.GetAxis ("RightStickX");

		if (turnsmoothing > 0) {
			smoothX = Mathf.SmoothDamp (smoothX, x, ref smoothXvelocity, turnsmoothing);
			smoothY = Mathf.SmoothDamp (smoothY, -y, ref smoothYvelocity, turnsmoothing);
		} else {
			smoothX = x;
			smoothY = y;
		}

		lookAngle += smoothX * turnSpeed;
		transform.rotation = Quaternion.Euler (0f, lookAngle, 0);

		tiltAngle -= smoothY * turnSpeed;
		tiltAngle = Mathf.Clamp (tiltAngle, -tiltMin, tiltMax);

		pivot.localRotation = Quaternion.Euler (tiltAngle, 0, 0);
	}
}
