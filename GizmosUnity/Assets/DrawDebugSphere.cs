using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DrawDebugSphere : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	public void OnDrawGizmos ()
	{
		if (gameObject.name == "WayPointYellow") {
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere (transform.position, 1);
		}
		if (gameObject.name == "WayPointRed") {
			Gizmos.color = Color.red;
			Gizmos.DrawSphere (transform.position, 1);
		}
	}

}
