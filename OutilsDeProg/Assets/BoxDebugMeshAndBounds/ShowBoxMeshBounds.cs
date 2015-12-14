// Show mesh bounds

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ShowBoxMeshBounds : MonoBehaviour {

	public List<Transform> _boxesToDebug = new List<Transform>();
	
	void OnDrawGizmos ()
	{
		Gizmos.color = Color.green;
		foreach(Transform i in _boxesToDebug)
		{
			if(i != null)
			{
				Gizmos.DrawCube(i.GetComponent<MeshRenderer>().bounds.center, i.GetComponent<MeshRenderer>().bounds.size);
			}
		}
	}
}
