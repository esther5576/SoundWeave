using UnityEngine;
using System.Collections;

public class Powers : MonoBehaviour {


	public bool boom;

	public float radius = 5.0F;
	public float power = 100.0F;
	public float _explosionLift = 100.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		if(boom == true)
		{
			Collider[] _hitColliders = Physics.OverlapSphere(transform.position, radius);
			foreach (Collider hit in _hitColliders)
			{
				if (hit && hit.GetComponent<Rigidbody>() && hit.tag == "cube")
				{
					hit.GetComponent<Rigidbody>().AddExplosionForce(power, transform.position, radius, _explosionLift);
				}
				
			}
		}

	}
}
