using UnityEngine;
using System.Collections;

public class Powers : MonoBehaviour
{


	public bool boom;

	public float radius = 5.0F;
	public float power = 100.0F;
	public float _explosionLift = 100.0f;

	public int countLeft;
	public int countRight;

	public float timer = 2;
	float actualTimer = 2;

	public bool trigger1;
	public bool trigger2;

	public bool trigger3;
	public bool trigger4;

	public float _totalTime = 0.1f;
	public float _time;
	// Use this for initialization
	void Start ()
	{
		trigger1 = true;
		trigger2 = true;
		actualTimer = timer;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (boom == true) {
			if (actualTimer >= 0) {
				actualTimer -= Time.deltaTime;
			} else {
				actualTimer = timer;
				boom = false;
			}

			Collider[] _hitColliders = Physics.OverlapSphere (transform.position, radius);
			foreach (Collider hit in _hitColliders) {
				if (hit && hit.GetComponent<Rigidbody> () && hit.tag == "cube") {
					hit.GetComponent<Rigidbody> ().AddExplosionForce (power, transform.position, radius, _explosionLift);
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button4)) {
			//FMODUnity.RuntimeManager.PlayOneShot ("event:/feedbacks/grow", transform.localPosition);
		}
		if (Input.GetKeyDown (KeyCode.Joystick1Button5)) {
			//FMODUnity.RuntimeManager.PlayOneShot ("event:/feedbacks/enlarge", transform.localPosition);
		}
		if (Input.GetAxis ("360_Triggers") < -0.9 && trigger1 == false) {
			//FMODUnity.RuntimeManager.PlayOneShot ("event:/feedbacks/push", transform.localPosition);
			trigger1 = true;
		} 
		if (Input.GetAxis ("360_Triggers") > 0.9 && trigger2 == false) {
			//FMODUnity.RuntimeManager.PlayOneShot ("event:/feedbacks/split", transform.localPosition);
			trigger2 = true;
		}
		if ((Input.GetAxis ("360_Triggers") < 0.9 && Input.GetAxis ("360_Triggers") > -0.9)) {
			trigger1 = false;
			trigger2 = false;
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (other.tag == "cube") {
			if (Input.GetKeyDown (KeyCode.Joystick1Button4)) {
				other.GetComponent<CubePowers> ().positionCube = other.transform.position;
				other.GetComponent<CubePowers> ().heightGrowingAcive = true;
				other.GetComponent<Renderer> ().material.color = Color.red;
			}
			if (Input.GetKeyDown (KeyCode.Joystick1Button5)) {
				other.GetComponent<CubePowers> ().biggerGrowActive = true;
				other.GetComponent<Renderer> ().material.color = Color.blue;
			}
			
			if (Input.GetAxis ("360_Triggers") < -0.9 && trigger3 == false) {
				other.GetComponent<CubePowers> ().bouncyActive = true;
				other.GetComponent<Renderer> ().material.color = Color.green;
				trigger3 = true;
				boom = true;
			} 
			if (Input.GetAxis ("360_Triggers") > 0.9 && trigger4 == false) {
				other.GetComponent<CubePowers> ().explosionCube = true;
				other.GetComponent<Renderer> ().material.color = Color.yellow;
				boom = true;

				//dupliquer 1 seul cube trigger4 doit etre activé
				//trigger4 = true;

				_time += Time.deltaTime;

				if (_time >= _totalTime) {
					trigger4 = true;
				}
			} 
			if ((Input.GetAxis ("360_Triggers") < 0.9 && Input.GetAxis ("360_Triggers") > -0.9)) {
				trigger3 = false;
				trigger4 = false;
				_time = 0;
			}
		}
	}


}
