using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveToWayPoint : MonoBehaviour
{

	public List<Transform> myWayPoints;
	public float speed = 10f;
	int i = 0;

	// Use this for initialization
	void Start ()
	{
		//myWayPoints = new List<Transform> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, myWayPoints [i].transform.position, step);
	}

	void OnTriggerEnter (Collider col)
	{
		if (i < myWayPoints.Count - 1) {
			if (col.tag == "waypoint") {
				i ++;
			}
		} else {
			i = 0;
		}
	}

	void OnDrawGizmos ()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine (transform.position, myWayPoints [i].transform.position);
	}
}
