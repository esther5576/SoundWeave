// Show mesh bounds

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ShowBoxMeshBounds : MonoBehaviour 
{
	[Header("Gizmo type")]
	[Tooltip("True for wired debug and false for whole cube mesh debug")]
	public bool T_wired_F_whole_Cube;

	[Header("")]

	[Header("List of Transforms to debug")]
	[Tooltip("List of boxes to debug box mesh bounds")]
	public List<Transform> _boxesToDebug = new List<Transform>();

	void OnDrawGizmos ()
	{
		Gizmos.color = Color.green;

		if(T_wired_F_whole_Cube == true)
		{
			foreach(Transform i in _boxesToDebug)
			{
				if(i != null)
				{
					Gizmos.DrawWireCube(i.GetComponent<MeshRenderer>().bounds.center, i.GetComponent<MeshRenderer>().bounds.size);
				}
			}
		}

		if(T_wired_F_whole_Cube == false)
		{
			foreach(Transform i in _boxesToDebug)
			{
				if(i != null)
				{
					Gizmos.DrawCube(i.GetComponent<MeshRenderer>().bounds.center, i.GetComponent<MeshRenderer>().bounds.size);
				}
			}
		}

	}
}
