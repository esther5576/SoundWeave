using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour
{

	private Transform _ParentTransform;
	private Rigidbody _Rigidbody;

	public float _Speed = 1;

	// Use this for initialization
	void Awake ()
	{
		_ParentTransform = transform.parent;
		_Rigidbody = transform.parent.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void FixedUpdate ()
	{
		Vector3 _Direction = (Camera.main.transform.forward * Input.GetAxisRaw ("LeftStickY")) + Camera.main.transform.right * Input.GetAxisRaw ("LeftStickX");
		_Direction *= _Speed;
		_Rigidbody.velocity = new Vector3 (_Direction.x, _Rigidbody.velocity.y, _Direction.z);
	}
}
