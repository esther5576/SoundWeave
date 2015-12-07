﻿using UnityEngine;
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
	// Use this for initialization
	void Start ()
	{
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
			FMODUnity.RuntimeManager.PlayOneShot ("event:/feedbacks/sonL1", transform.localPosition);
		}
		if (Input.GetKeyDown (KeyCode.Joystick1Button5)) {
			FMODUnity.RuntimeManager.PlayOneShot ("event:/feedbacks/sonR1", transform.localPosition);
		}
		FMODUnity.RuntimeManager.PlayOneShot ("event:/feedbacks/sonR2");
		if (Input.GetAxis ("360_Triggers") < -0.9 /*&& countLeft == 0*/ && trigger1 == false) {
			FMODUnity.RuntimeManager.PlayOneShot ("event:/feedbacks/sonL2", transform.localPosition);
			trigger1 = true;
		} 
		if (Input.GetAxis ("360_Triggers") > 0.9 /*&& countRight == 0*/ && trigger2 == false) {
			FMODUnity.RuntimeManager.PlayOneShot ("event:/feedbacks/sonR2", transform.localPosition);
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
				//FMODUnity.RuntimeManager.PlayOneShot ("event:/feedbacks/sonL1");
				
			}
			if (Input.GetKeyDown (KeyCode.Joystick1Button5)) {
				other.GetComponent<CubePowers> ().biggerGrowActive = true;
				other.GetComponent<Renderer> ().material.color = Color.blue;
				//FMODUnity.RuntimeManager.PlayOneShot ("event:/feedbacks/sonR1");
			}
			
			if (Input.GetAxis ("360_Triggers") < -0.9 /*&& countLeft == 0*/) {
				other.GetComponent<CubePowers> ().bouncyActive = true;
				other.GetComponent<Renderer> ().material.color = Color.green;
				//countLeft ++;
				//FMODUnity.RuntimeManager.PlayOneShot ("event:/feedbacks/sonL2");
			} 
			/*else if (Input.GetAxis ("360_Triggers") < -0.9) 
			{
				countLeft = 0;
			}*/
			
			if (Input.GetAxis ("360_Triggers") > 0.9 /*&& countRight == 0*/) {
				other.GetComponent<CubePowers> ().explosionCube = true;
				other.GetComponent<Renderer> ().material.color = Color.yellow;
				boom = true;
				countLeft ++;
				//FMODUnity.RuntimeManager.PlayOneShot ("event:/feedbacks/sonR2");
			} 
			/*else if (Input.GetAxis ("360_Triggers") < 0.9) 
			{
				countRight = 0;
			}*/
		}
	}


}
