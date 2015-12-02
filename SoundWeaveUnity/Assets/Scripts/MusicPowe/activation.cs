using UnityEngine;
using System.Collections;

public class activation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "cube") {
			other.transform.GetComponent<Visualize3d>().enabled = true;
			//other.transform.GetComponent<MeshRenderer>().enabled = true;
		}
	}

	/*void OnTriggerExit(Collider other) {
		if (other.tag == "cube") {
			other.transform.GetComponent<Visualize3d>().enabled = false;
			other.transform.GetComponent<MeshRenderer>().enabled = true;
			//other.transform.localScale = new Vector3(1, 1, 1);

			//Vector3 _previousScale = other.transform.localScale;
			Vector3 _previousScale = new Vector3(1f,0.5f,1f);
			other.transform.localScale = _previousScale;
			
			other.transform.position = new Vector3 (other.transform.position.x, other.transform.localScale.y/2, other.transform.position.z);
		}
	}*/
}
