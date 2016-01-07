using UnityEngine;
using System.Collections;

public class PlayerInputPower : MonoBehaviour
{
	#region push power variables

	//Push Power
	public float Force;

	#endregion

	#region split power variables

	//Split Power
	public bool Trigger;
	public float Timer;
	public float TotalTime;

	#endregion

	void OnTriggerStay (Collider other)
	{
		if (other.tag == "cube") {

			#region Height power
			//HEIGHT Power
			if (Input.GetKeyDown (KeyCode.Joystick1Button0)) {
				other.transform.localScale = new Vector3 (other.transform.localScale.x, 2, other.transform.localScale.z);
				other.GetComponent<CubeModifications> ().IncreaseDecrease = true;
				other.GetComponent<CubeModifications> ().IncreaseDecreaseHeight = true;
			}
			if (Input.GetKey (KeyCode.Joystick1Button0)) {
				other.GetComponent<CubeModifications> ().GrowHeightFunctionActive = true;
				other.GetComponent<Renderer> ().material.color = new Color (0.709f, 0.792f, 0.627f);
			} else {
				other.GetComponent<CubeModifications> ().GrowHeightFunctionActive = false;
			}

			if (Input.GetKeyUp (KeyCode.Joystick1Button0)) {
				other.GetComponent<Renderer> ().material.color = new Color (0.9f, 0.9f, 0.9f);
			}
			#endregion

			#region Grow power
			//GROW Power
			if (Input.GetKeyDown (KeyCode.Joystick1Button2)) {
				other.transform.localScale = new Vector3 (2, other.transform.localScale.y, 2);
			}
			if (Input.GetKey (KeyCode.Joystick1Button2)) {
				other.GetComponent<CubeModifications> ().GrowFunctionActive = true;
				other.GetComponent<Renderer> ().material.color = new Color (0.647f, 0.870f, 0.894f);
			} else {
				other.GetComponent<CubeModifications> ().GrowFunctionActive = false;
			}

			if (Input.GetKeyUp (KeyCode.Joystick1Button2)) {
				other.GetComponent<Renderer> ().material.color = new Color (0.9f, 0.9f, 0.9f);
			}
			#endregion

			if (Input.GetKey (KeyCode.Joystick1Button2) && Input.GetKey (KeyCode.Joystick1Button0)) {
				other.GetComponent<Renderer> ().material.color = new Color (0.400f, 0.729f, 0.717f);
			}

			#region Push power
			//PUSH Power
			if (Input.GetAxis ("360_Triggers") < -0.9) {
				other.GetComponent<Rigidbody> ().isKinematic = false;
				other.GetComponent<Rigidbody> ().AddForce (Camera.main.transform.forward * Force, ForceMode.Impulse);
				other.GetComponent<Renderer> ().material.color = new Color (0.980f, 0.839f, 0.637f);
			}
			#endregion

			#region split power
			//SPLIT POWER
			if (Input.GetAxis ("360_Triggers") > 0.9 && Trigger == false) {

				other.GetComponent<Rigidbody> ().isKinematic = false;
				other.GetComponent<CubeModifications> ().divisionOfCubesActive = true;
				other.GetComponent<Renderer> ().material.color = new Color (0.956f, 0.654f, 0.725f);

				Timer += Time.deltaTime;
				if (Timer >= TotalTime) {
					Trigger = true;
				}
			} 
			if ((Input.GetAxis ("360_Triggers") < 0.9 && Input.GetAxis ("360_Triggers") > -0.9)) {
				Trigger = false;
				Timer = 0;
				other.GetComponent<CubeModifications> ().divisionOfCubesActive = false;
			}
			#endregion
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.tag == "cube") {
			other.GetComponent<CubeModifications> ().GrowHeightFunctionActive = false;
			other.GetComponent<CubeModifications> ().GrowFunctionActive = false;
			other.GetComponent<Renderer> ().material.color = new Color (0.9f, 0.9f, 0.9f);
		}
	}
}
