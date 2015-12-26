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
			if (Input.GetKey (KeyCode.Joystick1Button4)) {
				other.GetComponent<CubeModifications> ().GrowHeightFunctionActive = true;
			} else {
				other.GetComponent<CubeModifications> ().GrowHeightFunctionActive = false;
			}
			#endregion

			#region Grow power
			//GROW Power
			if (Input.GetKey (KeyCode.Joystick1Button5)) {
				other.GetComponent<CubeModifications> ().GrowFunctionActive = true;
			} else {
				other.GetComponent<CubeModifications> ().GrowFunctionActive = false;
			}
			#endregion

			#region Push power
			//PUSH Power
			if (Input.GetAxis ("360_Triggers") < -0.9) {
				other.GetComponent<Rigidbody> ().isKinematic = false;
				other.GetComponent<Rigidbody> ().AddForce (Camera.main.transform.forward * Force, ForceMode.Impulse);
			}
			#endregion

			#region split power
			//SPLIT POWER
			if (Input.GetAxis ("360_Triggers") > 0.9 && Trigger == false) {

				other.GetComponent<Rigidbody> ().isKinematic = false;
				other.GetComponent<CubeModifications> ().divisionOfCubesActive = true;

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
		}
	}
}
