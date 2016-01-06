using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour
{

	private Transform _ParentTransform;
	private Rigidbody _Rigidbody;

	public float _Speed = 1;
	
	#region Camera system
	[Tooltip("Aiming system activated")]
	public bool
		aim = false;
	private float aimingWeight;
	private float aimingWeight2;
	private GameObject cameraContainer;
	private Transform cam;
	[Tooltip("Normal position of the camera")]
	public Vector3
		_normalState = new Vector3 ();
	[Tooltip("Aiming position of the camera")]
	public Vector3
		_aimingState = new Vector3 ();
	public Vector3 _dezoomState = new Vector3 ();
	public bool dezoom;
	public float zoomDezoomSpeed;
	#endregion

	// Use this for initialization
	void Awake ()
	{
		_ParentTransform = transform.parent;
		_Rigidbody = transform.parent.GetComponent<Rigidbody> ();
		#region Camera system
		cameraContainer = GameObject.Find ("Camera");
		
		if (Camera.main != null) {
			cam = Camera.main.transform;
		}
		#endregion
	}
	
	void LateUpdate ()
	{
		if (this.GetComponent<Jump> ()._Grounded == false && Input.GetAxisRaw ("RightStickY") > -0.05 && Input.GetAxisRaw ("RightStickY") < 0.05)
			Debug.Log ("caca");
		#region Aiming system
		//Aiming system
		if (cameraContainer.GetComponent<CameraSysthemFreeCameraLoopEstherV2> ().tiltAngle <= 0.5f) {
			aim = true;
		} else {
			aim = false;
		}

		if (cameraContainer.GetComponent<CameraSysthemFreeCameraLoopEstherV2> ().tiltAngle > 45 || (this.GetComponent<Jump> ()._Grounded == false && Input.GetAxisRaw ("RightStickY") > -0.05 && Input.GetAxisRaw ("RightStickY") < 0.05)) {
			dezoom = true;
		} else {
			dezoom = false;
		}
		
		aimingWeight = Mathf.MoveTowards (aimingWeight, (aim) ? 1.0f : 0.0f, Time.deltaTime * zoomDezoomSpeed);
		aimingWeight2 = Mathf.MoveTowards (aimingWeight2, (dezoom) ? 1.0f : 0.0f, Time.deltaTime * zoomDezoomSpeed);
		
		Vector3 normalState = _normalState;
		Vector3 aimingState = _aimingState;
		Vector3 dezoomState = _dezoomState;
		
		Vector3 posZoom = Vector3.Lerp (normalState, aimingState, aimingWeight);

		Vector3 posDezoom = Vector3.Lerp (normalState, dezoomState, aimingWeight2);

		//cam.transform.localPosition = posZoom + posDezoom;
		
		if (aim == false) {
			//UI_pointer.GetComponent<CanvasGroup> ().alpha = 0;
			cameraContainer.GetComponent<CameraSysthemFreeCameraLoopEstherV2> ().tiltMin = 3;
		} else {
			cameraContainer.GetComponent<CameraSysthemFreeCameraLoopEstherV2> ().tiltMin = 10;
			cam.transform.localPosition = posZoom;
		}

		if (dezoom == false) {
			//UI_pointer.GetComponent<CanvasGroup> ().alpha = 0;
		} else {
			cam.transform.localPosition = posDezoom;
			if (cameraContainer.GetComponent<CameraSysthemFreeCameraLoopEstherV2> ().tiltAngle < 15) {
				cameraContainer.GetComponent<CameraSysthemFreeCameraLoopEstherV2> ().tiltAngle += aimingWeight2 * 3;
			}
		}

		if (aim == false && cameraContainer.GetComponent<CameraSysthemFreeCameraLoopEstherV2> ().tiltAngle < 15 && dezoom == false) {
			cam.transform.localPosition = posZoom;
		}
		if ((dezoom == false && cameraContainer.GetComponent<CameraSysthemFreeCameraLoopEstherV2> ().tiltAngle < 45 && cameraContainer.GetComponent<CameraSysthemFreeCameraLoopEstherV2> ().tiltAngle >= 15 && aim == false) || (this.GetComponent<Jump> ()._Grounded == true && Input.GetAxisRaw ("RightStickY") > -0.05 && Input.GetAxisRaw ("RightStickY") < 0.05 && cameraContainer.GetComponent<CameraSysthemFreeCameraLoopEstherV2> ().tiltAngle >= 15)) {
			cam.transform.localPosition = posDezoom;
		}
		#endregion
	}
	
	void FixedUpdate ()
	{
		Vector3 _Direction = ((cameraContainer.transform.forward) * Input.GetAxisRaw ("LeftStickY")) + cameraContainer.transform.right * Input.GetAxisRaw ("LeftStickX");
		//Vector3 _Direction = (Camera.main.transform.forward * Input.GetAxisRaw ("LeftStickY")) + Camera.main.transform.right * Input.GetAxisRaw ("LeftStickX");
		_Direction *= _Speed;
		_Rigidbody.velocity = new Vector3 (_Direction.x, _Rigidbody.velocity.y, _Direction.z);
	}
}
