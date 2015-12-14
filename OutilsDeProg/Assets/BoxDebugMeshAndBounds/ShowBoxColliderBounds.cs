//This script will show the box colliders in editor

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ShowBoxColliderBounds : MonoBehaviour 
{
	[Header("Gizmo type")]
	[Tooltip("True for wired debug and false for whole cube mesh debug")]
	public bool T_wired_F_whole_Cube;

	[Header("")]

	[Header("List of Transforms to debug")]
	[Tooltip("List of boxes to debug box collider bounds")]
	public List<Transform> _boxesToDebug = new List<Transform>();

	void OnDrawGizmos ()
	{
		Gizmos.color = Color.yellow;

		if(T_wired_F_whole_Cube == true)
		{
			foreach(Transform i in _boxesToDebug)
			{
				if(i != null)
				{
					Gizmos.DrawWireCube(i.GetComponent<BoxCollider>().bounds.center, i.GetComponent<BoxCollider>().bounds.size);
				}
			}
		}

		if(T_wired_F_whole_Cube == false)
		{
			foreach(Transform i in _boxesToDebug)
			{
				if(i != null)
				{
					Gizmos.DrawCube(i.GetComponent<BoxCollider>().bounds.center, i.GetComponent<BoxCollider>().bounds.size);
				}
			}
		}
	}
}
