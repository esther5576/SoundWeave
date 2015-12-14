//Debug la somme des forces appliquees

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PhysicsVisualizer : MonoBehaviour {

	[Header("List of Transforms to debug")]
	[Tooltip("List of boxes to debug physics")]
	public List<Transform> _boxesToDebug = new List<Transform>();
	
	void Update ()
	{
		foreach(Transform i in _boxesToDebug)
		{
			if(i != null && i.GetComponent<Rigidbody>() != null)
			{
				Debug.DrawLine (i.position, i.position + i.GetComponent<Rigidbody> ().velocity, Color.black);
			}
		}
	}

}
