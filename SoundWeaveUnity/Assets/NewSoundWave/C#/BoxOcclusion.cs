using UnityEngine;
using System.Collections;

public class BoxOcclusion : MonoBehaviour
{
	public GameObject _camera;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	
		//RaycastHit hitInfo;
		//Ray rayFromCamPos = new Ray (_camera.transform.position, transform.position);
		//Debug.DrawRay (rayFromCamPos.origin, rayFromCamPos.direction, Color.green);*/
		//Debug.DrawLine (rayFromCamPos.origin, transform.position, Color.red);

		//Debug.Log (_camera.transform.position);

		//Debug.DrawLine (_camera.transform.position, transform.position, Color.red);

		/*RaycastHit hit;
		if (Physics.Raycast (rayFromCamPos, out hit, Mathf.Infinity)) {
			if (hit.transform.tag == "Player") {
				Debug.DrawLine (rayFromCamPos.origin, hit.transform.position, Color.red);
				Debug.Log ("hit");
			}
		}*/
		/*RaycastHit hitInfo = new RaycastHit ();

		hitInfo = Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, 100.0F);

		if (hitInfo.collider != null)
			Debug.Log (hitInfo.collider.name);*/

		//Ray rayToCameraPos = new Ray (Camera.main.transform.position, transform.position - Camera.main.transform.position);
		//Ray rayToCameraPos = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		//Vector3 dir = Camera.main.transform.position - gameObject.transform.position;



		/*if (Physics.Raycast (rayToCameraPos.origin, rayToCameraPos.direction, out hitInfo)) {
			//Debug.Log (hitInfo.collider.name + ", " + hitInfo.collider.tag);
			Debug.Log (hitInfo.collider.name);
			//hitInfo.transform.GetComponent<Renderer> ().material.color = Color.green;
			//Debug.Log (rayToCameraPos.origin);
			//Debug.DrawLine (rayToCameraPos.origin, hitInfo.collider.transform.position, Color.red);
			Debug.DrawRay (rayToCameraPos.origin, rayToCameraPos.direction * 100, Color.red);
		}*/



		RaycastHit[] hits;
		hits = Physics.RaycastAll (Camera.main.transform.position, Camera.main.transform.forward, 100.0F);
		
		for (int i = 0; i < hits.Length; i++) {
			RaycastHit hit = hits [i];
			//Renderer rend = hit.transform.GetComponent<Renderer> ();

			Debug.Log (hit.collider.name);

			/*if (rend) {
				// Change the material of all hit colliders
				// to use a transparent shader.
				rend.material.shader = Shader.Find ("Transparent/Diffuse");
				Color tempColor = rend.material.color;
				tempColor.a = 0.5F;
				rend.material.color = tempColor;
			}*/
		}

	}
}
