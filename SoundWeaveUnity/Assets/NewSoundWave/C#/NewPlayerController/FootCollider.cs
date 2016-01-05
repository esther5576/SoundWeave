using UnityEngine;
using System.Collections;

public class FootCollider : MonoBehaviour
{

	private Jump _JumpScript;

	public Transform _Parent;

	private Vector3 _parentposChange = Vector3.zero;

	private Vector3 _previousParentPos;
	private float _PreviousParentRotY = 0.0f;
	private float _StartRotationY;


	private bool _NoParent = true;



	// Use this for initialization
	void Start ()
	{
		_JumpScript = transform.parent.Find ("Scripts").GetComponent<Jump> ();
	}

	void Update ()
	{
		if (_Parent) {
			if (!_NoParent) {
				_parentposChange = _Parent.position - _previousParentPos;
				transform.parent.position += _parentposChange;
				//MouseLook._RotationCustom += _Parent.localRotation.eulerAngles.y - _PreviousParentRotY;
			}
			_previousParentPos = _Parent.position;
			_PreviousParentRotY = _Parent.localRotation.eulerAngles.y;

			_NoParent = false;
		} else {
			_NoParent = true;

		}

	}


	// Update is called once per frame
	void FixedUpdate ()
	{

	}

	void OnTriggerStay (Collider _Coll)
	{
		if (_Coll.tag != "Player") {
			_JumpScript._Grounded = true;
			
			_Parent = _Coll.transform;
		}
	}

	void OnTriggerExit (Collider _Coll)
	{
		if (_Coll.tag != "Player") {
			_JumpScript._Grounded = false;
			_Parent = null;
		}
	}




}
