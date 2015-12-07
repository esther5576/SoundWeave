using UnityEngine;
using System.Collections;

public class Powers : MonoBehaviour {


	public bool boom;

	public float radius = 5.0F;
	public float power = 100.0F;
	public float _explosionLift = 100.0f;

	public int countLeft;
	public int countRight;

	public float timer = 2;
	float actualTimer = 2;
	// Use this for initialization
	void Start () 
	{
		actualTimer = timer;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(boom == true)
		{
			if(actualTimer >= 0)
			{
				actualTimer -= Time.deltaTime;
			}
			else
			{
				actualTimer = timer;
				boom = false;
			}

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

	void OnTriggerStay(Collider other) 
	{
		if(other.tag == "cube")
		{
			if(Input.GetKeyDown(KeyCode.Joystick1Button4))
			{
				other.GetComponent<CubePowers>().positionCube = other.transform.position;
				other.GetComponent<CubePowers>().heightGrowingAcive = true;
				other.GetComponent<Renderer> ().material.color = Color.red;
			}
			if(Input.GetKeyDown(KeyCode.Joystick1Button5))
			{
				other.GetComponent<CubePowers>().biggerGrowActive = true;
				other.GetComponent<Renderer> ().material.color = Color.blue;
			}
			
			if (Input.GetAxis ("360_Triggers") < -0.9 /*&& countLeft == 0*/) 
			{
				other.GetComponent<CubePowers>().bouncyActive  = true;
				other.GetComponent<Renderer> ().material.color = Color.green;
				//countLeft ++;
			} 
			/*else if (Input.GetAxis ("360_Triggers") < -0.9) 
			{
				countLeft = 0;
			}*/
			
			if (Input.GetAxis ("360_Triggers") > 0.9 /*&& countRight == 0*/) 
			{
				other.GetComponent<CubePowers>().explosionCube = true;
				other.GetComponent<Renderer> ().material.color = Color.yellow;
				boom = true;
				countLeft ++;
			} 
			/*else if (Input.GetAxis ("360_Triggers") < 0.9) 
			{
				countRight = 0;
			}*/
		}
	}


}
