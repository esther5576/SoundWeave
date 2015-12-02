using UnityEngine;
using System.Collections;

public abstract class CameraSysthemEstherV2 : MonoBehaviour
{

	[SerializeField]
	public Transform
		target;
	[SerializeField]
	private bool
		autoTargetPlayer = true;
	

	// Use this for initialization
	virtual protected void Start ()
	{
		if (autoTargetPlayer) {
			FindTargetPlayer ();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (autoTargetPlayer && (target == null || ! target.gameObject.activeSelf)) {
			FindTargetPlayer ();
		}

		if (target != null) {
			Follow (Time.deltaTime);
		}
	}

	protected abstract void Follow (float deltaTime);

	public void FindTargetPlayer ()
	{
		if (target == null) {
			GameObject targetObj = GameObject.FindGameObjectWithTag ("Player");

			if (targetObj) {
				SetTarget (targetObj.transform);
			}
		}
	}

	public virtual void SetTarget (Transform newTransform)
	{
		target = newTransform;
	}

	public Transform Target {
		get{ return this.target;}
	}
}
