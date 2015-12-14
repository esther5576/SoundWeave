using UnityEngine;
using System.Collections;

public class DrawForce : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		Physics.gravity = new Vector3 (0, -5.0F, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.DrawLine (transform.position, transform.position + this.GetComponent<Rigidbody> ().velocity, Color.black);
	}
}
