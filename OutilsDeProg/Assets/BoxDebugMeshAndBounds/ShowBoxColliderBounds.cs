//This script will show the box colliders in editor

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ShowBoxColliderBounds : MonoBehaviour 
{
	public List<Transform> _boxesToDebug = new List<Transform>();

	void OnDrawGizmos ()
	{
		Gizmos.color = Color.yellow;
		foreach(Transform i in _boxesToDebug)
		{
			if(i != null)
			{
				Gizmos.DrawWireCube(i.GetComponent<BoxCollider>().bounds.center, i.GetComponent<BoxCollider>().bounds.size);
			}
		}

	}
}
